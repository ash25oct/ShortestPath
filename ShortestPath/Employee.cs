using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath    
{   /// <summary>
    /// Represents the employee and its attributes.
    /// </summary> 
    public class Employee
    {
        /// <summary>
        /// Identification number of the employee.
        /// </summary>
        private readonly int ID;
        /// <summary>
        /// Name of the employee.
        /// </summary>
        private readonly string Name;

        /// <summary>
        /// The list of reportees.
        /// </summary>
        private readonly List<Employee> Reports;

        /// <summary>
        /// Initializes the employee with ID and name.
        /// </summary>
        /// <param name="id">Identification of the employee.</param>
        /// <param name="name">Name of the employee.</param>
        public Employee(int id, String name)
        {
            this.ID = id;
            this.Name = name;
            this.Reports = new List<Employee>();
        }

        /// <summary>
        /// Gets the ID of the employee.
        /// </summary>
        /// <returns>Returns the ID of the employee.</returns>
        public int GetId()
        {
            return ID;
        }

        /// <summary>
        /// Gets the name of the employee.
        /// </summary>
        /// <returns>Returns the name of the employee.</returns>
        public String GetName()
        {
            return Name;
        }

        /// <summary>
        /// Gets the list of reports under the employee.
        /// </summary>
        /// <returns>Returns the list of reportees.</returns>
        public List<Employee> GetReports()
        {
            return Reports;
        }

        /// <summary>
        /// Adds the reportees.
        /// </summary>
        /// <param name="employee">Reporting Employee.</param>
        public void AddReport(Employee employee)
        {
            Reports.Add(employee);
        }
    }
}
