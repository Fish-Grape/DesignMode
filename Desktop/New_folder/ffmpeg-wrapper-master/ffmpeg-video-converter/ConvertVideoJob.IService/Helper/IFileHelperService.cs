using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConvertVideoJob.IService.Helper
{
    public interface IFileHelperService
    {
        /// <summary>
        /// 递归遍历
        /// </summary>
        /// <param name="pathname"></param>
        /// <param name="list"></param>
        void GetFilesRecursion(string pathname, ref List<string> list);
        /// <summary>
        /// 使用队列遍历
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        void GetFilesQueue(string path, ref List<string> list);
        /// <summary>
        /// 使用堆栈遍历
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        void GetFilesStack(string path, List<string> list);
        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileRule"></param>
        void GetFiles(string path, Action<FileInfo> fileRule);
    }
}
