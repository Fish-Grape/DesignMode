using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.SimpleFactory
{
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            if (NumberB == 0)
                throw new Exception("除数不能为0");
            return NumberA / NumberB;
        }
    }
}
