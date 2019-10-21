using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ObserverMode
{
    abstract class Observer
    {
        protected string name;
        protected Subject sub;

        protected Observer(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }

        public abstract void Update();
    }
}
