using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.DecorateMode
{
    public class Person
    {
        private string name;

        public Person()
        {
        }

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine("装扮的{0}", name);
        }
    }
}
