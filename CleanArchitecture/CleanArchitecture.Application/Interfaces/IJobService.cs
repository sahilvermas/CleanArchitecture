using System.Threading;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IJobService
    {
        string FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
