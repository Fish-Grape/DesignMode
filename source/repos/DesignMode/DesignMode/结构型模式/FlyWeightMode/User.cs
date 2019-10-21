using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.FlyWeightMode
{
    class User
    {
        private string name;

        public User(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
    }
}
