using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MediatorMode
{
    abstract class UnitedNations
    {
        public abstract void Declare(string message,Country colleague);
    }
}
