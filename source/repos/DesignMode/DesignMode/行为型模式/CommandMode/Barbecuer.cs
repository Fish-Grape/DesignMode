using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.CommandMode
{
    class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串");
        }

        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅");
        }
    }
}
