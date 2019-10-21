using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.StateMode
{
    abstract class State
    {
        public abstract void WriteProgram(Work w);
    }
}
