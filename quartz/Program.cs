using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Quartz.IoC;
using Quartz.Spi;

namespace quartz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IoC.BootStrap(new WindsorContainer());
            IoC.Container.Resolve<IQuartzInitializer>().Start();
        }
    }

    public static class IoC
    {
        public static IWindsorContainer Container { get; private set; }

        public static void BootStrap(IWindsorContainer container)
        {
            Container = container;

            IJobFactory jobFactory = new WindsorJobFactory(Container);

            Container.Register(Component.For<IJobFactory>().Instance(jobFactory));
            Container.Register(Component.For<IQuartzInitializer>().ImplementedBy<QuartzInitializer>());
            //Todo register own services

            var jobRegistrar = new JobRegistrar(Container);
            jobRegistrar.RegisterJobs();
        }
    }
}