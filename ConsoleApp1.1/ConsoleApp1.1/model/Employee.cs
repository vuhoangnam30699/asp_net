using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._1.model
{
    internal class Employee : Person
    {

        public Employee(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public Employee()
        {

        }

        public override void Display()
        {
            Console.WriteLine("Employee : " + this.Name + " - $" + this.Salary);
        }

        public override int GetBonus()
        {
            return 2 * this.Salary;
        }

        public override void Input()
        {
            string? role = null;
            while (string.IsNullOrWhiteSpace(role))
            {
                Console.Write("Enter Employee's Role: ");
                role = Console.ReadLine();
            }
            this.Name = role;

            int salary;
            do
            {
                Console.Write("Enter Employee's Salary: ");
            } while (!int.TryParse(Console.ReadLine(), out salary) || salary <= 0);

            this.Salary = salary;
        }
    }
}
