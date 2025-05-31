using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._1.model
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public abstract int GetBonus();
        public abstract void Input();
        public abstract void Display();


    }
}
