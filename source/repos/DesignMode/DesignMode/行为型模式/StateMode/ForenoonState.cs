using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.StateMode
{
    class ForenoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
                Console.WriteLine("当前时间：{0}点 上午工作，精神百倍",w.Hour);
            else
            {
                w.SetState(new NoonState());
                w.WriteProgram(); 
            }
        }
    }
}
