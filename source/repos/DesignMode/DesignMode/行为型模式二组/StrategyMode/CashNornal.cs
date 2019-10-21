using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.StrategyMode
{
    class CashNornal : CashSuper
    {
        public override double acceptCash(double money)
        {
            return money;
        }
    }
}
