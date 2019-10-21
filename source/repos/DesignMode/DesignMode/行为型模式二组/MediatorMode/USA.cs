using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MediatorMode
{
    class USA : Country
    {
        public USA(UnitedNations mediator) : base(mediator)
        {
        }

        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }

        public void GetMessage(string message)
        {
            Console.WriteLine("美国获取对方的消息：" + message);
        }
    }
}
