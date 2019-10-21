using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.SimpleFactory
{
    class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}
