using System;
using Quartz;

namespace quartz.job
{
    public class Job1 : IJob
    {
        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                throw new DivideByZeroException();
                Console.WriteLine("Job1 is executing.");
            }
            catch (Exception)
            {
                Console.WriteLine("Job1 throw exception.");
            }
        }

        #endregion
    }

    public class Job2 : IJob
    {
        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job2 is executing.");
        }

        #endregion
    }

    public class Job3 : IJob
    {
        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job3 is executing.");
        }

        #endregion
    }
}