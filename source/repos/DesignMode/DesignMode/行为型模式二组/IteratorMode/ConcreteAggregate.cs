using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.IteratorMode
{
    class ConcreteAggregate : Aggregate
    {
        private IList<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            set { items.Insert(index,value); }
            get { return items[index]; }
        }
    }
}
