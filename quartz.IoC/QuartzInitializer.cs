using Quartz.Impl;
using quartz.job;
using Quartz.Spi;

namespace Quartz.IoC
{
    public class QuartzInitializer : IQuartzInitializer
    {
        private readonly IJobFactory _jobFactory;

        private IScheduler sched;
        private ISchedulerFactory sf;

        public QuartzInitializer(IJobFactory jobFactory)
        {
            _jobFactory = jobFactory;
        }

        #region IQuartzInitializer Members

        public void Start()
        {
            sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();
            sched.JobFactory = _jobFactory;


            IJobDetail job1 = JobBuilder.Create<Job1>()
                .WithIdentity("job1", "group1")
                .Build();
            IJobDetail job2 = JobBuilder.Create<Job2>()
                .WithIdentity("job2", "group1")
                .Build();
            IJobDetail job3 = JobBuilder.Create<Job3>()
                .WithIdentity("job3", "group1")
                .Build();

            var trigger1 = (ICronTrigger) TriggerBuilder.Create()
                                              .WithIdentity("trigger1", "group1").StartNow()
                                              .WithCronSchedule("0/2 * * * * ?")
                                              .Build();
            var trigger2 = (ICronTrigger) TriggerBuilder.Create()
                                              .WithIdentity("trigger2", "group1").StartNow()
                                              .WithCronSchedule("0/5 * * * * ?")
                                              .Build();
            var trigger3 = (ICronTrigger) TriggerBuilder.Create()
                                              .WithIdentity("trigger3", "group1").StartNow()
                                              .WithCronSchedule("0/10 * * * * ?")
                                              .Build();

            sched.ScheduleJob(job1, trigger1);
            sched.ScheduleJob(job2, trigger2);
            sched.ScheduleJob(job3, trigger3);


            sched.Start();
        }

        #endregion
    }
}