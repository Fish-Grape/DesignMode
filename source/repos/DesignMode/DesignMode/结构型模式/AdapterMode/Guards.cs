using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.AdapterMode
{
    class Guards : Player
    {
        public Guards(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.WriteLine("后卫{0} 进攻",name);
        }

        public override void Defense()
        {
            Console.WriteLine("后卫{0} 防守", name);
        }
    }
}
