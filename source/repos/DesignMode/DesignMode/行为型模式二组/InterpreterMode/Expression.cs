using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.InterpreterMode
{
    abstract class Expression
    {
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length == 0)
                return;
            else
            {
                string playkey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(2);
                double playvalue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);

                Execute(playkey, playvalue);
            }
        }

        public abstract void Execute(string key, double value);
    }
}
