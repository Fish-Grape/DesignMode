using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.DecorateMode
{
    class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("大T恤 ");
            base.Show();
        }
    }
}
