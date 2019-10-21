using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.InterpreterMode
{
    class Scale : Expression
    {
        public override void Execute(string key, double value)
        {
            string note = "";
            switch (Convert.ToInt32(value))
            {
                case 1:
                    note = "低音";
                    break;
                case 2:
                    note = "中音";
                    break;
                case 3:
                    note = "高音";
                    break;
            }
            Console.Write("{0} ", note);
        }
    }
}
