using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    /// <summary>
    /// Represents the company and all the employees working for the company.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Employee> ListOfEmployees = new List<Employee>();
        /// <summary>
        /// 
        /// </summary>
        private const int EMPLOYEE_NAME = 1;
        /// <summary>
        /// 
        /// </summary>
        private const int EMPLOYEE_ID = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int TOTAL_ATTRIBUTE = 2;
        /// <summary>
        /// 
        /// </summary>
        private static readonly List<string> ResultShortestPath = new List<string>();
        /// <summary>
        /// Adjacency list to store the employee and their reportees
        /// </summary>
        private static readonly List<List<Employee>> EmployeeAdjList = new List<List<Employee>>();

        #region PublicMethods
        /// <summary>
        /// Computes the shortest path between two employees - first and second employee based on Depth first search.
        /// </summary>
        /// <param name="ceo">CEO or the root employee of the organisation.</param>
        /// <param name="firstEmployee">First or start employee in the shortest path.</param>
        /// <param name="secondEmployee">Second employee or the destination in the shortest path.</param>
        /// <returns></returns>
        public static string ShortestPath(Employee ceo, Employee firstEmployee, Employee secondEmployee)
        {
            if (ceo == null)
                throw new ArgumentException("CEO is not found.");
            
            if (firstEmployee == null)
                throw new ArgumentException("First Employee is not found.");
            
            if (secondEmployee == null)
                throw new ArgumentException("Second Employee is not found.");

            List<string> stack = new List<string>();
            DepthFirstSearch(firstEmployee, secondEmployee, stack);
            return FormatShortestPath(ResultShortestPath);
        }

        /// <summary>
        /// Gets the total count of employees in the company.
        /// </summary>
        /// <returns></returns>
        public static int GetTotalEmployeeCount()
        {
            return ListOfEmployees.Count;
        }

        /// <summary>
        /// Initializes the organisation structure from the file.
        /// </summary>
        /// <param name="filename"></param>
        public static void InitializeEmployees(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("Filename.");
            }

            InitializeEmployeesFromFile(filename);
        }

        /// <summary>
        /// Gets the employee information based on the Employee ID.
        /// </summary>
        /// <param name="employeeId">Employee ID.</param>
        /// <returns></returns>
        public static Employee GetEmployeeById(int employeeId)
        {
            return ListOfEmployees.Find(u => u.GetId() == employeeId);
        }

        /// <summary>
        /// Gets the employee information based on the Employee Name.
        /// </summary>
        /// <param name="name">Employee name.</param>
        /// <returns></returns>
        public static Employee GetEmployeeByName(string name)
        {
            return ListOfEmployees.Find(u => u.GetName().ToLower() == name.ToLower().Trim());
        }
        #endregion PublicMethods
       
        #region Private Methods
        /// <summary>
        /// Initializes the Employees from the given file.
        /// </summary>
        /// <param name="filename">Filename</param>
        private static void InitializeEmployeesFromFile(string filename)
        {
            int counter = 0;
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                counter++;
                if (counter > 1)
                {
                    if (line == "RELATIONS")
                    {
                        for (int k = 0; k < GetTotalEmployeeCount() + 1; k++)
                        {
                            EmployeeAdjList.Add(new List<Employee>());
                        }

                        //Read all the relations
                        for (int i = counter; i < lines.Length; i++)
                        {
                            string[] idParts = lines[i].Split(',');
                            int[] reportees = new int[idParts.Length];
                            int managerId = Int32.Parse(idParts[0].Trim());
                            for (int j = 1; j < idParts.Length; j++)
                            {
                                reportees[j] = Int32.Parse(idParts[j].Trim());
                                Employee reportee = GetEmployeeById(reportees[j]);
                                Employee manager = GetEmployeeById(managerId);
                                AddRelation(manager, reportee);
                            }
                        }
                        break;
                    }
                    else
                    {
                        // Initialise the employee list with ID and name  
                        string[] parts = line.Split('|');
                        string[] staffs = new string[TOTAL_ATTRIBUTE];
                        for (int i = 0; i < parts.Length; i++)
                        {
                            staffs[i] = parts[i].Trim();
                        }

                        int empId = Int32.Parse(staffs[EMPLOYEE_ID].Trim());

                        string name = staffs[EMPLOYEE_NAME];
                        ListOfEmployees.Add(new Employee(empId, name));
                    }
                }
            }
        }

       /// <summary>
       /// Adds the relationships with manager and the reportees.
       /// </summary>
       /// <param name="x">Manager employee.</param>
       /// <param name="y">Reporting employee</param>
        private static void AddRelation(Employee x, Employee y)
        {
            x.AddReport(y);
            EmployeeAdjList[x.GetId()].Add(y);
            EmployeeAdjList[y.GetId()].Add(x);
        }

        /// <summary>
        /// Formats the resulting shortest path in the format as Employee Name and ->.
        /// For example, Gabriel -> Eunice  if the result is Gabriel and Eunice.
        /// </summary>
        /// <param name="stack">List of employee names in the shortest path.</param>
        /// <returns>Shortest path is employees are found. Empty if no values present in the shortest path.</returns>
        private static string FormatShortestPath(List<string> stack)
        {
            string path = string.Empty;
            if (stack.Count == 0)
                return path;

            for (int i = 0; i < stack.Count - 1; i++)
            {
                path += stack[i] + " > ";
            }
            path += stack[stack.Count - 1];
            return path;
        }

        /// <summary>
        /// Performs a depth first search on the adjacency list for first and second employee recursively.
        /// </summary>
        /// <param name="vis">Visited employee nodes.</param>
        /// <param name="firstEmployee">First Employee of the path.</param>
        /// <param name="secondEmployee">Second Employee or the destination of the path.</param>
        /// <param name="stack">Contains resulting shortest path.</param>
        private static void DFS(bool[] vis, Employee firstEmployee, Employee secondEmployee, List<string> stack)
        {
            stack.Add(firstEmployee.GetName());
            if (firstEmployee.GetId() == secondEmployee.GetId())
            {
                // reaching the destination node   
                ResultShortestPath.Clear();
                ResultShortestPath.AddRange(stack);
                return;
            }
            var x = firstEmployee.GetId();
            vis[x] = true;

            // if backtracking is taking place      
            if (EmployeeAdjList[x].Count > 0)
            {
                for (int j = 0; j < EmployeeAdjList[x].Count; j++)
                {
                    // if the node is not visited
                    if (vis[EmployeeAdjList[x][j].GetId()] == false)
                    {
                        DFS(vis, EmployeeAdjList[x][j], secondEmployee, stack);
                    }
                }
            }
            stack.RemoveAt(stack.Count - 1);
        }

        /// <summary>
        /// An utility to initialise the visited nodes and to find the shortest path via Depth First Search.
        /// </summary>
        /// <param name="firstEmployee">First Employee of the path.</param>
        /// <param name="secondEmployee">Second Employee or the destination of the path.</param>
        /// <param name="n">Total number of employees.</param>
        /// <param name="stack">Contains resulting shortest path.</param>
        private static void DepthFirstSearch(Employee firstEmployee, Employee secondEmployee, 
                            List<string> stack)
        {
            int n = GetTotalEmployeeCount();
            
            // Initialize the visited array
            bool[] vis = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
                vis[i] = false;

            // Perform Depth First Search to find the shortest path.
            DFS(vis, firstEmployee, secondEmployee, stack);

        }
        #endregion PrivateMethods
    }
}
