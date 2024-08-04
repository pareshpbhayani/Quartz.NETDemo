using Quartz;

namespace Quartz.NETDemo
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello, Quartz.NET! 🕒");
            return Task.CompletedTask;
        }
    }
}
