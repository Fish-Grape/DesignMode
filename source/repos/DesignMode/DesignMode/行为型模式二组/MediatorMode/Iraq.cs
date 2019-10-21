using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MediatorMode
{
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator) : base(mediator)
        {
        }
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }

        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获取对方的消息：" + message);
        }
    }
}
