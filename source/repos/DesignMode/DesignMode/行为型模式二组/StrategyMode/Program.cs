using System;

namespace DesignMode.行为型模式二组.StrategyMode
{
    class Program
    {
        static void Run()
        {
            CashContext cssuper = new CashContext("打8折");
            double totalprice = cssuper.GetResult(800);
        }
    }
}
