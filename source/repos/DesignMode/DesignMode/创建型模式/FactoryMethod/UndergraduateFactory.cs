using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.FactoryMethod
{
    class UndergraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }
}
