using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.VistorMode
{
    class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();
        public void Attach(Person element)
        {
            elements.Add(element);
        }

        public void Detach(Person element)
        {
            elements.Remove(element);
        }

        public void Display(Action vistor)
        {
            foreach (Person e in elements)
                e.Accept(vistor);
        }
    }
}
