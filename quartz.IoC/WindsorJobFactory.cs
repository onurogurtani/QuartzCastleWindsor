using Castle.Windsor;
using Quartz.Spi;

namespace Quartz.IoC
{
    public class WindsorJobFactory : IJobFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorJobFactory(IWindsorContainer container)
        {
            _container = container;
        }

        #region IJobFactory Members

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob) _container.Resolve(bundle.JobDetail.JobType);
        }

        #endregion
    }
}