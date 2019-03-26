using System.Collections.Generic;
using ConvertVideoJob.IService;
using ConvertVideoJob.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConvertVideoJob.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IConvertVideoService convertVideo;

        public VideoController(IConvertVideoService convertVideo)
        {
            this.convertVideo = convertVideo;
        }

        /// <summary>
        /// 获取视频信息
        /// </summary>
        /// <param name="path">源路径</param>
        /// <returns>视频信息模型</returns>
        [Route("info")]
        [HttpGet]
        public JsonResult GetVideoInfoFromPath(string path)
        {
            return new JsonResult(convertVideo.GetVideoInfo(path));
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="path">源路径</param>
        /// <returns>生产缩略图地址</returns>
        [Route("thm")]
        [HttpGet]
        public string GetThumbnailImg(string path)
        {
            return convertVideo.GetThumbnailImg(path);
        }
    }
}
