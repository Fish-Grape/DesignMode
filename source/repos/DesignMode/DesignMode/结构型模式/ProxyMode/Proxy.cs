using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.ProxyMode
{
    class Proxy : GiveGift
    {
        Persuit gg;

        public Proxy(SchoolGirl mm)
        {
            this.gg = new Persuit(mm);
        }

        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }

        public void GiveDolls()
        {
            gg.GiveDolls();
        }

        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
    }
}
