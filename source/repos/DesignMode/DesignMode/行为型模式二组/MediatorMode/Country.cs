using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MediatorMode
{
    abstract class Country
    {
        protected UnitedNations mediator;

        protected Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }
}
