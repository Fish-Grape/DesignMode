using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.VistorMode
{
    class Man : Person
    {
        public override void Accept(Action vistor)
        {
            vistor.GetManConclusion(this);
        }
    }
}
