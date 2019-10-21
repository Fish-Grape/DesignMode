using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.DecorateMode
{
    class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.Write("垮裤 ");
            base.Show();
        }
    }
}
