using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式二组.MementoMode
{
    class RoleStateCaretaker
    {
        private RoleStateMemento memento;

        internal RoleStateMemento Memento { get => memento; set => memento = value; }
    }
}
