using ConvertVideoJob.IService;
using ConvertVideoJob.IService.Helper;
using ConvertVideoJob.Model;
using ConvertVideoJob.Service.Factory;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConvertVideoJob.Service
{
    public class ConvertVideoService : IConvertVideoService
    {
        private readonly IFileHelperService fileHelper;
        private readonly IConfigService config;
        private readonly IQuartzHelperService quartzHelper;

        public ConvertVideoService(IFileHelperService fileHelperService, IConfigService config
            , IQuartzHelperService quartzHelper)
        {
            this.quartzHelper = quartzHelper;
            this.config = config;
            fileHelper = fileHelperService;
            // Create temp conversion folder if not existing
            _tempPath = Directory.GetCurrentDirectory() + TEMP_PATH;
            _logPath = Directory.GetCurrentDirectory() + LOG_PATH;
            Directory.CreateDirectory(_tempPath);

            //get config waiting for convert type
            NeedType = config.GetAppSettings<ConfigPara>("ConvertParam").NeedConvertType;
            OutputType = config.GetAppSettings<ConfigPara>("ConvertParam").OutputType.ToLower();
            fps = config.GetAppSettings<ConfigPara>("ConvertParam").OutputFPS;
            width = config.GetAppSettings<ConfigPara>("ConvertParam").OutputWidth;
            height = config.GetAppSettings<ConfigPara>("ConvertParam").OutputHeight;
        }


        const string APP_PATH = @"External\ffmpeg.exe";
        const string TEMP_PATH = @"\temp";
        const string LOG_PATH = @"\log";
        readonly string[] ALL_VIDEO_TYPE = new string[] {
            "MPEG", "MPG", "DAT", "AVI","BLU－RAY",
        "MOV","ASF","WMV","NAVI","3GP","REAL VIDEO","MKV",
            "FLV","F4V","RMVB","WebM","HDDVD","QSV"};

        private string _tempPath;
        private string _logPath;
        private bool _isVerboseLoggingEnabled = true;    // TODO: make configurable in tool
        private bool _isCleanUpEnabled = true;           // TODO: make configurable in tool
        private VideoModel videoInfo;
        private string NeedType;
        private string OutputType;
        private int fps;
        private int width;
        private int height;

        #region interface function

        public VideoModel GetVideoInfo(string path)
        {
            videoInfo = new VideoModel();

            //path
            videoInfo.Path = path;

            //type
            FileInfo file = new FileInfo(path);
            string filePath = file.Extension.Substring(1, file.Extension.Length-1).ToUpper();
            if (filePath != "3GP")
                videoInfo.MediaType = (VideoType)Enum.Parse(typeof(VideoType), filePath, false);
            else
                videoInfo.MediaType = VideoType.THREE_GP;

            string fullAppPath = Path.GetFullPath(APP_PATH);
            //显示基本信息
            string[] args = new string[2];
            args[0] = string.Format("-i \"{0}\"", path);
            args[1] = " -n OUTPUT";

            CallConsoleAppAsync(fullAppPath, args);

            return videoInfo;
        }

        public void ConvertAllInDirectory(string sourcePath, string outputPath)
        {
            //计时工具，需要System.Diagnostics
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //use multipable threads
            List<Task> tasks = new List<Task>();
            Task tsk = null;

            string filePath = string.Empty;
            VideoModel model = new VideoModel();
            //get all files in the inderctory
            fileHelper.GetFiles(sourcePath, (FileInfo file) =>
            {
                filePath = file.Extension.Substring(1, file.Extension.Length - 1).ToUpper();
                //if file is not video type. return
                if (!JudgeIfVideo(filePath))
                    return;

                model = GetVideoInfo(file.FullName);
                if (NeedType.Contains(model.MediaType.ToString()))
                {
                    if (model.FrameWidth > width)
                        model.FrameWidth = width;
                    if (model.FrameHeight > height)
                        model.FrameHeight = height;
                    if (model.FrameRate > fps)
                        model.FrameRate = fps;

                    //stratConvert(file.FullName, outputPath);
                    tsk = new Task(() => { stratConvert(model, outputPath); });
                    tsk.Start();
                    tasks.Add(tsk);
                }
            });

            WaitAll(tasks.ToArray());
            sw.Stop();
            WriteLog(string.Format("======================All threads have done,cost time:{0}ms,{1}s,{2}min==============",sw.Elapsed.TotalMilliseconds
                ,sw.Elapsed.TotalSeconds,sw.Elapsed.TotalMinutes),true);
            WriteLog(" ", true);
            WriteLog(" ", true);
            sw.Reset();
        }

        public string ConvertOneFile(string sourcePath, string outputPath = "")
        {
            if (string.IsNullOrEmpty(outputPath))
                outputPath = Path.GetDirectoryName(sourcePath);
            VideoModel model= GetVideoInfo(sourcePath);
            if (model.FrameWidth > width)
                model.FrameWidth = width;
            if (model.FrameHeight > height)
                model.FrameHeight = height;
            if (model.FrameRate > fps)
                model.FrameRate = fps;

            if (NeedType.Contains(model.MediaType.ToString()))
                return stratConvert(model, outputPath);
            else
                return sourcePath;
        }


        public void StartJobBasedOnConfig()
        {
            string cornString = config.GetAppSettings<ConfigPara>("ConvertParam").CornString;
            quartzHelper.ExecuteByCron<MyJob>(cornString).GetAwaiter().GetResult();
        }

        public void shutDownConvertJob()
        {
            quartzHelper.shutDownJob();
        }

        #endregion interface function

        #region 任务执行例
        public class MyJob : IJob
        {
            Creator creator = ConvertFactory.Instance;
            IConfigService config;
            IConvertVideoService convertVideo;

            public MyJob()
            {
                config = creator.CreateConfigFactory();
                convertVideo = creator.CreateConvertFactory();
            }

            public Task Execute(IJobExecutionContext context)
            {
                string sourcePath = config.GetAppSettings<ConfigPara>("ConvertParam").SourcePath;
                string outputPath = config.GetAppSettings<ConfigPara>("ConvertParam").OutputPath;
                convertVideo.ConvertAllInDirectory(sourcePath, outputPath);

                return null;
            }
        }
        #endregion

        private static object objlock = new object();

        #region tool functions

        /// <summary>
        /// Copy source file, call ffmpeg to convert, copy converted file back, delete temp files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string stratConvert(VideoModel model, string sourceDirectory)
        {
            string fullAppPath = Path.GetFullPath(APP_PATH);

            lock (objlock)
            {
                if (File.Exists(model.Path.Trim()))
                {
                    // Copy file to temp directory
                    string sourceFileName = Path.GetFileName(model.Path);
                    string tempIn = string.Format(@"{0}\{1}", _tempPath, sourceFileName);
                    File.Copy(model.Path, tempIn, true);

                    string destinationFileName = Path.GetFileNameWithoutExtension(tempIn);
                    string tempOut = string.Format(@"{0}\{1}."+ OutputType, _tempPath, destinationFileName);

                    // Build the command parameters
                    string[] args = new string[8];
                    args[0] = string.Format("-i \"{0}\"", tempIn);
                    //args[1] = string.Format("-ss {0}", startTime);  // starting at hh:mm:ss[.xxx]
                    //args[2] = string.Format("-t {0}", duration);    // limit duration to hh:mm:ss[.xxx]
                    args[1] = "-r " + model.FrameRate;
                    args[2] = "-s " + model.FrameWidth + "*" + model.FrameHeight;
                    args[3] = "-ac 1";
                    args[4] = "-ar 11025";
                    args[5] = "-y";                                 // Force override
                    args[6] = "-hide_banner";                       // Hide unrequired output
                    args[7] = string.Format("\"{0}\"", tempOut);

                    // Call ffmpeg to convert file
                    CallConsoleAppAsync(fullAppPath, args);

                    // Copy converted file back to origin (append "(x)" if already existing)
                    string destinationPath = string.Format(@"{0}\{1}."+ OutputType, sourceDirectory, destinationFileName);

                    int suffix = 1;
                    while (File.Exists(destinationPath))
                    {
                        destinationPath = string.Format(@"{0}\{1}({2})."+ OutputType, sourceDirectory, destinationFileName, suffix);
                        suffix++;
                    }

                    try
                    {
                        if (!File.Exists(destinationPath))
                            File.Copy(tempOut, destinationPath);
                    }
                    catch (Exception ex)
                    {
                        WriteLog(string.Format("Could not copy temporary file '{0}' to {1}: {2}", tempOut, destinationPath, ex.Message), true, true);
                    }
                    finally
                    {
                        WriteLog(string.Format("Saved converted file to '{0}'.", destinationPath), true);
                    }

                    // Delete temp files if enabled and copying was successful
                    if (_isCleanUpEnabled)
                    {
                        // TempIn
                        if (_isVerboseLoggingEnabled)
                            WriteLog(string.Format("Deleting temporary input file '{0}'...", tempIn), true);

                        try
                        {
                            if (File.Exists(tempIn))
                                File.Delete(tempIn);
                        }
                        catch (Exception ex)
                        {
                            WriteLog(string.Format("Could not delete temporary input file '{0}': {1}", tempIn, ex.Message), true, true);
                        }

                        // TempOut
                        if (_isVerboseLoggingEnabled)
                            WriteLog(string.Format("Deleting temporary output file '{0}'...", tempOut), true);

                        try
                        {
                            if (File.Exists(tempOut))
                                File.Delete(tempOut);
                        }
                        catch (Exception ex)
                        {
                            WriteLog(string.Format("Could not delete temporary output file '{0}': {1}", tempOut, ex.Message), true);
                        }
                    }

                    return destinationPath;
                }
                else
                {
                    WriteLog(string.Format("Could not find '{0}'", model.Path), true);
                    return "sourcePath cant not be null";
                }
            }
        }

        #region Process Handling
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appPath"></param>
        /// <param name="args"></param>
        string CallConsoleApp(string appPath, string[] args = null)
        {
            string command = " " + string.Join(" ", args);

            if (_isVerboseLoggingEnabled)
                WriteLog(string.Format("Parameters: {0}", command));

            // Create process
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = command;

            // Set UseShellExecute to false to allow redirection
            process.StartInfo.UseShellExecute = false;

            // Redirect the standard output and error
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            string result = string.Empty;

            process.StartInfo.CreateNoWindow = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(Output);//外部程序(这里是FFMPEG)输出流时候产生的事件,这里是把流的处理过程转移到下面的方法中,详细请查阅MSDN
                                                                              
            process.Start();// Start the process

            // Read output
            if (process.StartInfo.RedirectStandardOutput)
            {
                string output=process.StandardOutput.ReadToEnd();
                WriteLog(output);
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                string error = process.StandardError.ReadToEnd();
                WriteLog(error);
            }

            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_ExitedAsync);

            process.WaitForExit();

            return result;
        }

        void CallConsoleAppAsync(string appPath, string[] args = null)
        {
            string command = " " + string.Join(" ", args);

            if (_isVerboseLoggingEnabled)
                WriteLog(string.Format("Parameters: {0}", command),true);

            // Create process
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = command;

            // Set UseShellExecute to false to allow redirection
            process.StartInfo.UseShellExecute = false;

            // Redirect the standard output and error
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.StartInfo.CreateNoWindow = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(Output);//外部程序(这里是FFMPEG)输出流时候产生的事件,这里是把流的处理过程转移到下面的方法中,详细请查阅MSDN

            try
            {
                // Start the process
                process.Start();
                process.BeginErrorReadLine();
                //CallWithTimeout(process.BeginErrorReadLine);//开始异步读取,并设置超时时间
                process.WaitForExit();//阻塞等待进程结束
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, true, true);
                throw ex;
            }
            finally
            {
                process.Close();//关闭进程
                process.Dispose();//释放资源
            }
        }

        //try the method with a 6 second timeout
        void CallWithTimeout(Action action, int timeoutMilliseconds = 6000)
        {
            Thread threadToKill = null;
            Action wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                action();
            };
            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                threadToKill.Abort();
                throw new TimeoutException();
            }
        }

        private void Output(object sendProcess, DataReceivedEventArgs output)
        {
            if (!String.IsNullOrEmpty(output.Data))
            {
                if (output.Data.Contains("Duration:"))
                {
                    Regex regex = new Regex("Duration: (\\d{2}):(\\d{2}):([0-9]+(.[0-9]{1,2})?)", RegexOptions.Compiled);
                    Match m = regex.Match(output.Data);
                    if (m.Success)
                    {
                        videoInfo.Duration = double.Parse(m.Groups[1].Value) * 60 * 60
                            + double.Parse(m.Groups[2].Value) * 60
                            + double.Parse(m.Groups[3].Value);
                    }
                }

                if (output.Data.Contains("Video:"))
                {
                    //通过正则表达式获取信息里面的宽度信息
                    Regex regex = new Regex("(\\d{2,4})x(\\d{2,4})", RegexOptions.Compiled);
                    Match m = regex.Match(output.Data);
                    if (m.Success)
                    {
                        videoInfo.FrameWidth = int.Parse(m.Groups[1].Value);
                        videoInfo.FrameHeight = int.Parse(m.Groups[2].Value);
                    }

                    //fps
                    regex = new Regex("([0-9]{1,3})+(.[0-9]{1,2})? fps", RegexOptions.Compiled);
                    m = regex.Match(output.Data);
                    if (m.Success)
                        videoInfo.FrameRate = double.Parse(m.Groups[1].Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void process_ExitedAsync(object sender, EventArgs e)
        {
            if (_isVerboseLoggingEnabled)
                WriteLog("Conversion Done. Process exited.");
        }
        #endregion

        private static object loglock = new object();

        #region Logging
        /// <summary>
        /// Appends given string to the log textbox
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="linebreak"></param>
        public void WriteLog(string entry, bool linebreak = true,bool isError= false)
        {
            lock (loglock)
            {
                string formatedEntry = linebreak ? string.Format("{0}\n", entry) : entry;

                using (StreamWriter write = new StreamWriter(_logPath + "\\log.txt", true))
                {
                    write.Write(DateTime.Now.ToString() + " thredID:" + Thread.CurrentThread.ManagedThreadId + "   " + formatedEntry);
                }

                if (isError)
                {
                    using (StreamWriter write = new StreamWriter(_logPath + "\\error.txt", true))
                    {
                        write.Write(DateTime.Now.ToString() + " thredID:" + Thread.CurrentThread.ManagedThreadId + "   " + formatedEntry);
                    }
                }
            }
        }

        /// <summary>
        /// 等待所有的Task运行结束
        /// </summary>
        /// <param name="tsks">等待的Task类</param>
        public void WaitAll(params Task[] tsks)
        {
            foreach (var t in tsks)
            {
                t.Wait();
            }
        }

        #endregion

        private bool JudgeIfVideo(string type)
        {
            bool flag = false;
            foreach(string video_type in ALL_VIDEO_TYPE)
            {
                if (video_type == type)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        #endregion tool functions
    }
}
