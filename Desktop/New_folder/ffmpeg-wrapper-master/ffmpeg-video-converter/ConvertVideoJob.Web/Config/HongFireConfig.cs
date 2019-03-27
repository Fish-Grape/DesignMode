using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertVideoJob.Web.Config
{
    public class HongFireConfig
    {
        public static string ConnectionString= "Data Source=172.17.1.60,7619;Initial Catalog=Mars;User ID=MerchantApp;Password=AppMerchant";
        public static string providerName = "System.Data.SqlClient";

        public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
        {
            //这里需要配置权限规则
            public bool Authorize(DashboardContext context)
            {
                return true;
            }
        }
    }
}
