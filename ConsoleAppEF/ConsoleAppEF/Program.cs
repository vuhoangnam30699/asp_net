using ConsoleAppEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            T2301E_SEM3Entities dbContext = new T2301E_SEM3Entities();
            try
            {
                // new

                //Employee emp = new Employee();
                //emp.FirstName = "John";
                //emp.LastName = "Smith";
                //emp.Email = "johnsmith@example.com";

                //dbContext.Employees.Add(emp);
                //dbContext.SaveChanges();

                // update

                //Employee emp = dbContext.Employees.Find(1);
                //if (emp != null)
                //{
                //    Console.WriteLine("Found");
                //    // 
                //}
                

                // SELECT

                var employee = (from emp in  dbContext.Employees
                                where emp.EmpId == 1
                                select emp).First();

                Employee empl = (Employee) employee;
                Console.WriteLine("EmpId: " + empl.EmpId);
                Console.WriteLine("Name: " + empl.FirstName + " " + empl.LastName);
                Console.WriteLine("Email: " + empl.Email);

                //foreach( Employee emp in employee )
                //{
                //    Console.WriteLine("EmpId: " + emp.EmpId);
                //    Console.WriteLine("Name: " + emp.FirstName + " " + emp.LastName);
                //    Console.WriteLine("Email: " + emp.Email);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
