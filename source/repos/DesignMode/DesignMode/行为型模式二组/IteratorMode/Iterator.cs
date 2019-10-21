using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.IteratorMode
{
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
}
