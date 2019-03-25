using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertVideoJob.Model
{
    public class ConfigPara
    {
        /// <summary>
        /// 源像素(宽)
        /// </summary>
        public int MaxWidth { get; set; }
        /// <summary>
        /// 源像素(高)
        /// </summary>
        public int MaxHeight { get; set; }
        /// <summary>
        /// 源fps
        /// </summary>
        public int SourceFPS { get; set; }
        /// <summary>
        /// 目标像素(宽)
        /// </summary>
        public int OutputWidth { get; set; }
        /// <summary>
        /// 目标像素(高)
        /// </summary>
        public int OutputHeight { get; set; }
        /// <summary>
        /// 目标fps
        /// </summary>
        public int OutputFPS { get; set; }
        /// <summary>
        /// job执行规则
        /// </summary>
        public string CornString { get; set; }
        /// <summary>
        /// 源路径
        /// </summary>
        public string SourcePath { get; set; }
        /// <summary>
        /// 输出路径
        /// </summary>
        public string OutputPath { get; set; }
        /// <summary>
        /// 待转换类型
        /// </summary>
        public string NeedConvertType { get; set; }
        /// <summary>
        /// 目标类型
        /// </summary>
        public string OutputType { get; set; }
    }
}
