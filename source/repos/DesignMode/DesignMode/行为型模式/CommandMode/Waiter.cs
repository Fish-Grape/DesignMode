using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.CommandMode
{
    class Waiter
    {
        private IList<Command> orders = new List<Command>();

        public void SetOrder(Command command)
        {
            if(command.ToString()== "DesignMode.行为型模式.CommandMode.BakeChickenWingCommand")
            {
                Console.WriteLine("服务员：鸡翅没有了，请点别的烧烤");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单："+command.ToString()+
                    " 时间"+DateTime.Now.ToString());
            }
        }

        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单：" + command.ToString() +
                    " 时间" + DateTime.Now.ToString());
        }

        public void Notify()
        {
            foreach (Command cmd in orders)
                cmd.ExecuteCommand();
        }
    }
}
