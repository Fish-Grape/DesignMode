using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.CommandMode
{
    abstract class Command
    {
        protected Barbecuer receiver;

        protected Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }

        abstract public void ExecuteCommand();
    }
}
