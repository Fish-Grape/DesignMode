using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertVideoJob.IService.Helper
{
    public interface IConfigService
    {
        T GetAppSettings<T>(string key) where T : class, new();
    }
}
