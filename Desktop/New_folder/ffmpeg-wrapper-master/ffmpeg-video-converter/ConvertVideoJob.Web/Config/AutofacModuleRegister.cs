using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConvertVideoJob.Web
{
    public class AutofacModuleRegister : Autofac.Module
    {
        /// <summary>
        /// 装载autofac方式注册
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // 业务应用注册
            Assembly _assembly = Assembly.LoadFrom(@"bin\netstandard2.0\ConvertVideoJob.Service.dll");
            builder.RegisterAssemblyTypes(_assembly)
                .Where(t => !t.IsAbstract && !t.IsInterface && t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
