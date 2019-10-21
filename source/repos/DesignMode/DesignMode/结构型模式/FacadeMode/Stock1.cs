using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.FacadeMode
{
    class Stock1
    {
        public void Sell()
        {
            Console.WriteLine("股票1卖出");
        }

        public void Buy()
        {
            Console.WriteLine("股票1买入");
        }
    }
}
