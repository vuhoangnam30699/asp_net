using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._1.model
{
    internal class Director : Person
    {
        public Director(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public Director()
        {
            
        }

        public override void Display()
        {
            Console.WriteLine("Director : " + this.Name + " - $" + this.Salary);
        }

        public override int GetBonus()
        {
            return 5 * this.Salary;
        }

        public override void Input()
        {
            string? role = null;
            while (string.IsNullOrWhiteSpace(role))
            {
                Console.Write("Enter Director's Role: ");
                role = Console.ReadLine();
            }
            this.Name = role;

            int salary;
            do
            {
                Console.Write("Enter Director's Salary: ");
            } while (!int.TryParse(Console.ReadLine(), out salary) || salary <= 0);

            this.Salary = salary;
        }

    }
}
