using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.SingletonMode
{
    class Singleton
    {
        private static Singleton instance;
        private static readonly object syncRoot = new object();
        private Singleton() { }
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        return new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
