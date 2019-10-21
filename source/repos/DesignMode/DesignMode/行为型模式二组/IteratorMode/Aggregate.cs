using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.IteratorMode
{
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
}
