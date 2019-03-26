using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertVideoJob.Model.AppSettings
{
    public class ThumbnailParam
    {
        /// <summary>
        /// 帧处在的秒数
        /// </summary>
        public int FrameIndex { get; set; }
        /// <summary>
        /// 缩略图的宽度
        /// </summary>
        public int ThubWidth { get; set; }
        /// <summary>
        /// 缩略图的高度
        /// </summary>
        public int ThubHeight { get; set; }
        /// <summary>
        /// 生成的缩略图所在的路径
        /// </summary>
        public string ThubImagePath { get; set; }
    }
}
