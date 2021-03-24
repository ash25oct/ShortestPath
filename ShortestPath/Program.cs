using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filename = @".\InputFiles\Employees.txt";
            string ceo = "Eugene";
            string firstEmployee = "Gabriel";
            string secondEmployee = "Jimmy";
            
            Company.InitializeEmployees(filename);
           
            Console.WriteLine( Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee)));

            Console.WriteLine("Press any key to exit ..,");
            Console.ReadLine();

        }
    }
}
