using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MementoMode
{
    class RoleStateMemento
    {
        private int vit;
        private int atk;
        private int def;

        public RoleStateMemento(int vit, int atk, int def)
        {
            this.vit = vit;
            this.atk = atk;
            this.def = def;
        }

        public int Vitality { get => vit; set => vit = value; }
        public int Attack { get => atk; set => atk = value; }
        public int Defense { get => def; set => def = value; }
    }
}
