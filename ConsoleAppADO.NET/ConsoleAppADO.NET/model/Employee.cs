using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppADO.NET.model
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Id " + EmpId);
            Console.WriteLine("Name " + FirstName + " " + LastName);
            Console.WriteLine("Email " + Email);
        }

    }
}
