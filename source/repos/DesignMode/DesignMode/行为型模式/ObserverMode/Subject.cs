using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ObserverMode
{
    interface Subject
    {
        void Notify();
        string SubjectState { get; set; }
    }
}
