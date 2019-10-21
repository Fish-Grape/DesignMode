using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.DecorateMode
{
    class Finery : Person
    {
        protected Person component;
        public void Decorate(Person component)
        {
            this.component = component;
        }
        public override void Show()
        {
            if (component != null)
            {
                component.Show();
            }
        }
    }
}
