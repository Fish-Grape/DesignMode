using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.ProxyMode
{
    class Persuit : GiveGift
    {
        SchoolGirl mm;

        public Persuit(SchoolGirl mm)
        {
            this.mm = mm;
        }

        public void GiveChocolate()
        {
            Console.WriteLine("送你巧克力");
        }

        public void GiveDolls()
        {
            Console.WriteLine("送你洋娃娃");
        }

        public void GiveFlowers()
        {
            Console.WriteLine("送你鲜花");
        }
    }
}
