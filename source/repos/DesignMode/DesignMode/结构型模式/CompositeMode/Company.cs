using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.CompositeMode
{
    abstract class Company
    {
        protected string name;

        protected Company(string name)
        {
            this.name = name;
        }

        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();
    }
}
