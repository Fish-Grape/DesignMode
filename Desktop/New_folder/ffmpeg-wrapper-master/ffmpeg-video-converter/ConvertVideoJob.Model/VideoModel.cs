using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertVideoJob.Model
{
    public class VideoModel
    {
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public string Size { get; set; }
        public double FrameRate { get; set; }
        public VideoType MediaType { get; set; }
        public string Path { get; set; }
        /// <summary>
        /// second
        /// </summary>
        public double Duration { get; set; }
    }

    public enum VideoType
    {
        MP4=1,
        MOV=2,
        AVI=3,
        FLV=4,
        WMV=5,
        THREE_GP = 6,
    }
}
