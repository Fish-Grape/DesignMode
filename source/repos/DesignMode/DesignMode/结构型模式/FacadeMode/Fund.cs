using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.FacadeMode
{
    class Fund
    {
        Stock1 gu1;
        Stock2 gu2;
        Stock3 gu3;

        public Fund()
        {
            this.gu1 = new Stock1();
            this.gu2 = new Stock2();
            this.gu3 = new Stock3();
        }

        public void BuyFund()
        {
            gu1.Buy();
            gu2.Buy();
            gu3.Buy();
        }

        public void SellFund()
        {
            gu1.Sell();
            gu2.Sell();
            gu3.Sell();
        }
    }
}
