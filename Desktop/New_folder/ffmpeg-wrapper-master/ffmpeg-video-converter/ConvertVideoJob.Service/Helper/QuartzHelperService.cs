using ConvertVideoJob.IService.Helper;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace ConvertVideoJob.Service.Helper
{
    public class QuartzHelperService : IQuartzHelperService
    {
        private static IScheduler scheduler;

        public async Task<IScheduler> InitScheduler(bool ifInterval= true)
        {
            ISchedulerFactory factory = new StdSchedulerFactory();

            if (!ifInterval)
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                factory = new StdSchedulerFactory(props);
            }

            return await factory.GetScheduler();
        }

        /// <summary>
        /// 时间间隔执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="seconds">时间间隔(单位：毫秒)</param>
        public void ExecuteInterval<T>(int seconds) where T : IJob
        {
            scheduler = InitScheduler().Result;

            //IJobDetail job = JobBuilder.Create<T>().WithIdentity("job1", "group1").Build();
            IJobDetail job = JobBuilder.Create<T>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }

        /// <summary>
        /// 指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        public async Task ExecuteByCron<T>(string cronExpression) where T : IJob
        {
            try
            {
                scheduler = InitScheduler(false).Result;

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<T>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithCronSchedule(cronExpression)
                    .Build();
                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }

        public void shutDownJob()
        {
            if (scheduler == null)
                return;
            // and last shut down the scheduler when you are ready to close your program
            scheduler.Shutdown();
        }
    }
}
