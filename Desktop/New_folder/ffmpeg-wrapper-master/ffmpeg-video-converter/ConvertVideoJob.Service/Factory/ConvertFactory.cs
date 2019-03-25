using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ConvertVideoJob.IService;
using ConvertVideoJob.IService.Helper;
using ConvertVideoJob.Service.Helper;

namespace ConvertVideoJob.Service.Factory
{
    public class ConvertFactory : Creator
    {
        private static ConvertFactory _singleton;
        private ConvertFactory()
        {
        }

        public static ConvertFactory Instance
        {
            get
            {
                if (_singleton == null)
                {
                    Interlocked.CompareExchange(ref _singleton, new ConvertFactory(), null);
                }

                return _singleton;
            }
        }

        public override IConfigService CreateConfigFactory()
        {
            return new ConfigService();
        }

        public override IConvertVideoService CreateConvertFactory()
        {
            return new ConvertVideoService(CreateFileFactory(),
                CreateConfigFactory(),
                CreateQuartzFactory());
        }

        public override IFileHelperService CreateFileFactory()
        {
            return new FileHelperService();
        }

        public override IQuartzHelperService CreateQuartzFactory()
        {
            return new QuartzHelperService();
        }
    }
}
