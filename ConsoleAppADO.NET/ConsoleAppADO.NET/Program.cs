using ConsoleAppADO.NET.Controller;
using ConsoleAppADO.NET.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ADO.NET");

            EmployeeController employeeController = new EmployeeController();

            //Employee emp = new Employee
            //{
            //    FirstName = "Tom",
            //    LastName = "Hiddleston",
            //    Email = "tom@gmail.com"
            //};

            Employee empToUpdate = employeeController.FindById(1);

            //empToUpdate.FirstName = "Vu Hoang";
            //empToUpdate.LastName = "Nam";
            //empToUpdate.Email = "vuhoangnam@gmail.com";

            //employeeController.CreateNewEmp(emp);
            //employeeController.UpdateEmp(empToUpdate);
            //employeeController.DeleteEmp();


            Console.WriteLine("==========List Employee========");
            // employeeController.GetAllEmp();
            empToUpdate.Display();
        }
    }
}
