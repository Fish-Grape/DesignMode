using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.AdapterMode
{
    abstract class Player
    {
        protected string name;

        public Player(string name)
        {
            this.name = name;
        }

        public abstract void Attack();
        public abstract void Defense();
    }
}
