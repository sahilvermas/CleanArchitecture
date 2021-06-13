using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.Infrastructure.Hangfire.Extensions
{
    public static class AppExtensions
    {
        public static void UseHangfireDashboard(this IApplicationBuilder app)
        {
            HangfireApplicationBuilderExtensions.UseHangfireDashboard(app);
        }
    }
}
