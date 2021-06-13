using CleanArchitecture.Application.Interfaces;
using Hangfire;
using System;

namespace CleanArchitecture.Infrastructure.Hangfire.Repositories
{
    public class JobService : IJobService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public JobService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public string FireAndForgetJob()
        {
            return _backgroundJobClient.Enqueue(() => Console.WriteLine("Hello from a Fire and Forget job!"));

        }
        public void ReccuringJob()
        {
            Console.WriteLine("Hello from a Scheduled job!");
        }
        public void DelayedJob()
        {
            Console.WriteLine("Hello from a Delayed job!");
        }
        public void ContinuationJob()
        {
            Console.WriteLine("Hello from a Continuation job!");
        }
    }
}
