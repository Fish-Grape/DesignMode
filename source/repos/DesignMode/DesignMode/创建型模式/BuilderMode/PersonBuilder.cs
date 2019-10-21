using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DesignMode.创建型模式.BuilderMode
{
    abstract class PersonBuilder
    {
        protected Graphics g;
        protected Pen p;

        protected PersonBuilder(Graphics g, Pen p)
        {
            this.g = g;
            this.p = p;
        }

        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildArmLeft();
        public abstract void BuildArmRight();
        public abstract void BuildLegLeft();
        public abstract void BuildLegRight();
    }
}
