using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.model
{

    public interface IPerson // == pure abstract Class
    {
        public void Input(); // abstract method
        public void Display();
    }

    public class Manager : IPerson
    {
        void IPerson.Display()
        {
            throw new NotImplementedException();
        }

        void IPerson.Input()
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class AbstractPerson
    {
        public abstract void Input();
        public abstract void Display();

    }
}
