using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.model
{
    internal class Person : AbstractPerson
    {

        // properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // default constructor
        public Person()
        {
        
        }

        // parameter constructor (có chứa tham số)
        public Person(int id, string fName, string lName)
        {
            Id = id;
            FirstName = fName;
            LastName = lName;
        }


        // copy constructor
        public Person(Person otherPerson)
        {
            Id = otherPerson.Id;
            FirstName = otherPerson.FirstName;
            LastName = otherPerson.LastName;
        }

        public override void Input()
        {
        
        }

        public override void Display()
        {
            
        }
    }
}
