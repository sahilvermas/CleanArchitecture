using System;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}