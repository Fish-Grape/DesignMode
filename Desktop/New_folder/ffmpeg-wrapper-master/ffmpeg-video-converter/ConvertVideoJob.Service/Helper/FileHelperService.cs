using ConvertVideoJob.IService.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConvertVideoJob.Service.Helper
{
    public class FileHelperService : IFileHelperService
    {
        /// <summary>
        /// 递归遍历
        /// </summary>
        /// <param name="pathname"></param>
        /// <param name="list"></param>
        public void GetFilesRecursion(string pathname, ref List<string> list)
        {
            string[] subFiles = Directory.GetFiles(pathname);
            foreach (string subFile in subFiles)
            {
                //Console.WriteLine(subFile);
                list.Add(subFile);
            }

            string[] subDirs = Directory.GetDirectories(pathname);
            foreach (string subDir in subDirs)
            {
                GetFilesRecursion(subDir, ref list);
            }
        }
        /// <summary>
        /// 使用队列遍历
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        public void GetFilesQueue(string path, ref List<string> list)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(queue.Dequeue());
                foreach (DirectoryInfo dirchildInfo in dirInfo.GetDirectories())
                {
                    queue.Enqueue(dirchildInfo.FullName);
                }
                foreach (FileInfo filechildInfo in dirInfo.GetFiles())
                {
                    list.Add(filechildInfo.FullName);
                }

            }
        }
        /// <summary>
        /// 使用堆栈遍历
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        public void GetFilesStack(string path, List<string> list)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(path);
            while (stack.Count > 0)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(stack.Pop());
                foreach (DirectoryInfo dirchildinfo in dirInfo.GetDirectories())
                {
                    stack.Push(dirchildinfo.FullName);
                }
                foreach (FileInfo filechidlinfo in dirInfo.GetFiles())
                {
                    list.Add(filechidlinfo.FullName);
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileRule"></param>
        public void GetFiles(string path, Action<FileInfo> fileRule)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(queue.Dequeue());
                foreach (DirectoryInfo dirchildInfo in dirInfo.GetDirectories())
                {
                    queue.Enqueue(dirchildInfo.FullName);
                }

                foreach (FileInfo dirfileInfo in dirInfo.GetFiles())
                {
                    fileRule(dirfileInfo);
                }
            }
        }
    }
}
