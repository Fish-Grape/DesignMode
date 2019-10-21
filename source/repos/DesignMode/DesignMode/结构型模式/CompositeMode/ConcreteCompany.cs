using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.CompositeMode
{
    class ConcreteCompany : Company
    {
        private List<Company> children = new List<Company>();
        public ConcreteCompany(string name) : base(name)
        {
        }

        public override void Add(Company c)
        {
            children.Add(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string("-"+depth)+name);
            foreach (Company component in children)
                component.Display(depth + 2);
        }

        public override void LineOfDuty()
        {
            foreach (Company component in children)
                component.LineOfDuty();
        }

        public override void Remove(Company c)
        {
            children.Remove(c);
        }
    }
}
