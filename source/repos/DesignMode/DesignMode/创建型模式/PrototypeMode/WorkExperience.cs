using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.PrototypeMode
{
    class WorkExperience : ICloneable
    {
        public string WorkDate { get; set; }
        public string Company { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
