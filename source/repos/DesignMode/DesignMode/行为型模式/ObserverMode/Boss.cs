using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ObserverMode
{
    class Boss : Subject
    {
        public event Action Update;
        private string action;
        public string SubjectState
        {
            get { return action; }
            set { action = value; }
        }

        public void Notify()
        {
            Update();
        }
    }
}
