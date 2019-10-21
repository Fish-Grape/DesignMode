﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    class AccessDepartment : IDepartment
    {
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在Access中根据id得到一条Department记录");
            return null;
        }

        public void InsertDepartment(Department user)
        {
            Console.WriteLine("在Access中给Department表新增一条记录");
        }

    }
}
