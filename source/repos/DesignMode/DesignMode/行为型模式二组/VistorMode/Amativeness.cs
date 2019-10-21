using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.VistorMode
{
    class Amativeness : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时，凡是不懂也要装懂。", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void GetWoManConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时，遇事懂也装作不懂。", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
}
