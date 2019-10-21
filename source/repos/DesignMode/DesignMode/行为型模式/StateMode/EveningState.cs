using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.StateMode
{
    class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WriteProgram();
            }
            else
            {
                if (w.Hour < 21)
                    Console.WriteLine("当前时间：{0}点 加班哦，疲累之极", w.Hour);
                else
                {
                    w.SetState(new SleepingState());
                    w.WriteProgram();
                }
            }
        }
    }
}
