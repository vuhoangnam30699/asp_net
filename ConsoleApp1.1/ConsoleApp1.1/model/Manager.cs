using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._1.model
{
    internal class Manager : Person
    {
        public Manager(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public Manager()
        {

        }


        public override void Display()
        {
            Console.WriteLine("Manager : " + this.Name + " - $" + this.Salary);
        }

        public override int GetBonus()
        {
            return 3 * this.Salary;
        }

        public override void Input()
        {
            string? role = null;
            while (string.IsNullOrWhiteSpace(role))
            {
                Console.Write("Enter Manager's Role: ");
                role = Console.ReadLine();
            }
            this.Name = role;

            int salary;
            do
            {
                Console.Write("Enter Manager's Salary: ");
            } while (!int.TryParse(Console.ReadLine(), out salary) || salary <= 0);

            this.Salary = salary;
        }
    }
}
