using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ChainOfResponsibility
{
    abstract class Manager
    {
        protected string name;
        protected Manager superior;

        protected Manager(string name)
        {
            this.name = name;
        }

        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }

        abstract public void RequestApplications(Request request);
    }
}
