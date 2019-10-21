using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    class DataAccess
    {
        private static readonly string AssemblyName = "DesignMode";
        private static readonly string db =ConfigurationManager.AppSettings["db"];

        public static IUser CreateUser()
        {
            string className = AssemblyName + ".创建型模式.AbstractFactory." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }


        public static IDepartment CreateDepartment()
        {
            string className = AssemblyName + ".创建型模式.AbstractFactory." + db + "Department";
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
