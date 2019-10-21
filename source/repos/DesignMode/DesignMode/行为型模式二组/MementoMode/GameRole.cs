using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MementoMode
{
    class GameRole
    {
        private int vit;
        private int atk;
        private int def;
        public int Vitality { get => vit; set => vit = value; }
        public int Attack { get => atk; set => atk = value; }
        public int Defense { get => def; set => def = value; }

        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态：");
            Console.WriteLine("体力：{0}" + this.vit);
            Console.WriteLine("攻击力：{0}" + this.atk);
            Console.WriteLine("防御力：{0}" + this.def);
            Console.WriteLine("");
        }

        public void GetInitState()
        {
            this.vit = 100;
            this.atk = 100;
            this.def = 100;
        }

        public void Fight()
        {
            this.vit = 0;
            this.atk = 0;
            this.def = 0;
        }

        public RoleStateMemento SaveState()
        {
            return new RoleStateMemento(vit, atk, def);
        }

        public void RecoveryState(RoleStateMemento memento)
        {
            this.vit = memento.Vitality;
            this.atk = memento.Attack;
            this.def = memento.Defense;
        }
    }
}
