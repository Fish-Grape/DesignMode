using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.SingletonMode
{
    sealed class HungrySingleton
    {
        private static readonly HungrySingleton instance=new HungrySingleton();
        private HungrySingleton() { }
        public static HungrySingleton GetInstance()
        {
            return instance;
        }
    }
}
