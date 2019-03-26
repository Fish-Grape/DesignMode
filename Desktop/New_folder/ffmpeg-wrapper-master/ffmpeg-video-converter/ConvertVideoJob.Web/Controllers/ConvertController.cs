using System.Collections.Generic;
using ConvertVideoJob.IService;
using ConvertVideoJob.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConvertVideoJob.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IConvertVideoService convertVideo;

        public ConvertController(IConvertVideoService convertVideo)
        {
            this.convertVideo = convertVideo;
        }

        [Route("start_job")]
        [HttpGet]
        public void Get()
        {
            convertVideo.StartJobBasedOnConfig();
        }

        [Route("stop")]
        [HttpGet]
        public void Stop()
        {
            convertVideo.ShutDownConvertJob();
        }

        [Route("all")]
        [HttpPost]
        public void ConvertAllInDirectory([FromBody]PathRequestModel requestModel)
        {
            convertVideo.ConvertAllInDirectory(requestModel.source_path, requestModel.target_path);
        }

        [Route("one")]
        [HttpGet]
        public JsonResult ConvertOneFile(string sourcePath, string outputPath = "")
        {
            return new JsonResult(convertVideo.ConvertOneFile(sourcePath, outputPath));
        }
    }
}
