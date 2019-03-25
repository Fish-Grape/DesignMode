using ConvertVideoJob.IService;
using ConvertVideoJob.IService.Helper;

namespace ConvertVideoJob.Service.Factory
{
    public abstract class Creator
    {
        // 工厂方法
        public abstract IConfigService CreateConfigFactory();
        public abstract IFileHelperService CreateFileFactory();
        public abstract IQuartzHelperService CreateQuartzFactory();
        public abstract IConvertVideoService CreateConvertFactory();
    }
}
