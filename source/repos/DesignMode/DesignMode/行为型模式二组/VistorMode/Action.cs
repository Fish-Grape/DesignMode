using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.VistorMode
{
    abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWoManConclusion(Woman concreteElementB);
    }

    abstract class Person
    {
        public abstract void Accept(Action vistor);
    }
}
