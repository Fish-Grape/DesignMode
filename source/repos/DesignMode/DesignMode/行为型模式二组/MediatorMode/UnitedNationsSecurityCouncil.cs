using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MediatorMode
{
    class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA colleague1;
        private Iraq colleague2;

        internal USA Colleague1 { get => colleague1; set => colleague1 = value; }
        internal Iraq Colleague2 { get => colleague2; set => colleague2 = value; }

        public override void Declare(string message, Country colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            }
            else
            {
                colleague1.GetMessage(message);
            }
        }
    }
}
