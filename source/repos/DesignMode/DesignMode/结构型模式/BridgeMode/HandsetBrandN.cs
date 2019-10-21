using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.BridgeMode
{
    class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
}
