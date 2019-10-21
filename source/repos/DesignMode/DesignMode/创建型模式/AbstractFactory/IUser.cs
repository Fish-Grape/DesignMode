using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    interface IUser
    {
        void InsertUser(User user);
        User GetUser(int id);
    }
}
