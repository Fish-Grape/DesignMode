using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.AdapterMode
{
    class ForeignCenter 
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public void 进攻()
        {
            Console.WriteLine("外籍中锋{0} 进攻",Name);
        }

        public void 防守()
        {
            Console.WriteLine("外籍中锋{0} 防守", Name);
        }
    }
}
