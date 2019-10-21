using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    class SqlServerUser : IUser
    {
        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据id得到一条User记录");
            return null;
        }

        public void InsertUser(User user)
        {
            Console.WriteLine("在SQL Server中给User表新增一条记录");
        }
    }
}
