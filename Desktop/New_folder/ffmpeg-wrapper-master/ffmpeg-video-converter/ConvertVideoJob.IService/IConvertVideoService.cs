using ConvertVideoJob.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertVideoJob.IService
{
    public interface IConvertVideoService
    {
        /// <summary>
        /// get video details
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns></returns>
        VideoModel GetVideoInfo(string path);
        /// <summary>
        /// convert all files
        /// </summary>
        /// <param name="sourcePath">the directory files come from</param>
        /// <param name="outputPath">target directory you want to put</param>
        void ConvertAllInDirectory(string sourcePath, string outputPath);
        /// <summary>
        /// convert one file and return path
        /// </summary>
        /// <param name="sourcePath">the directory files come from</param>
        /// <param name="outputPath">target directory you want to put</param>
        /// <returns>file full path</returns>
        string ConvertOneFile(string sourcePath, string outputPath="");

        void StartJobBasedOnConfig();

        void shutDownConvertJob();
    }
}
