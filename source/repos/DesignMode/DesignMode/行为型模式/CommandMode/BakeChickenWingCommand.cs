using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.CommandMode
{
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver)
        {
        }

        public override void ExecuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }
}
