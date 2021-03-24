using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.Tests
{
    [TestClass()]
    public class CompanyTests
    {
        [TestInitialize]
        public void Initialize()
        {
            string filename = @".\InputFiles\Employees.txt";       

            Company.InitializeEmployees(filename);
        }

        [TestMethod()]
        public void ShortestPathTest1()
        {
            string ceo = "Eugene";
            string firstEmployee = "Gabriel";
            string secondEmployee = "Jimmy";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Gabriel > Eunice > Jimmy",shortestPath);
        }

        [TestMethod()]
        public void ShortestPathTest2()
        {
            string ceo = "Eugene";
            string firstEmployee = "Jimmy";
            string secondEmployee = "Bryan";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Jimmy > Eunice > Jose > Bryan", shortestPath);
        }

        [TestMethod()]
        public void ShortestPathTest3()
        {
            string ceo = "Eugene";
            string firstEmployee = "Jimmy";
            string secondEmployee = "Kelvin";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Jimmy > Eunice > Jose > Eugene > Kelvin", shortestPath);
        }

        [TestMethod()]
        public void ShortestPathTest4()
        {
            string ceo = "Eugene";
            string firstEmployee = "Eunice";
            string secondEmployee = "Jimmy";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Eunice > Jimmy", shortestPath);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "CEO is not found.")]
        public void ShortestPathTest5()
        {
            string ceo = "Jane";
            string firstEmployee = "Eunice";
            string secondEmployee = "Jimmy";
            Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));          
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "First Employee is not found.")]
        public void ShortestPathTest6()
        {
            string ceo = "Eugene";
            string firstEmployee = "Junice";
            string secondEmployee = "Jimmy";
            Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "Second Employee is not found.")]
        public void ShortestPathTest7()
        {
            string ceo = "Eugene";
            string firstEmployee = "Eunice";
            string secondEmployee = "Fimmy";
            Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
        }

        [TestMethod()]
        public void ShortestPathTest8()
        {
            string ceo = "Eugene";
            string firstEmployee = "Eunice";
            string secondEmployee = "Eunice";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Eunice", shortestPath);
        }

        [TestMethod()]
        public void ShortestPathTest9()
        {
            string ceo = "Eugene";
            string firstEmployee = "Eugene";
            string secondEmployee = "Eugene";
            string shortestPath = Company.ShortestPath(Company.GetEmployeeByName(ceo), Company.GetEmployeeByName(firstEmployee), Company.GetEmployeeByName(secondEmployee));
            Assert.AreEqual("Eugene", shortestPath);
        }
    }
}