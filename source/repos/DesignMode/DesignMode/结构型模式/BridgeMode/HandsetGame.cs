using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.BridgeMode
{
    class HandsetGame : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机游戏");
        }
    }
}
