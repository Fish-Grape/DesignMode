using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.BridgeMode
{
    abstract class HandsetBrand
    {
        protected HandsetSoft soft;

        public void SetHandsetSoft(HandsetSoft soft)
        {
            this.soft = soft;
        }
        public abstract void Run();
    }
}
