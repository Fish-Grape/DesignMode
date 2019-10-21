using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    interface IDepartment
    {
        void InsertDepartment(Department user);
        Department GetDepartment(int id);
    }
}
