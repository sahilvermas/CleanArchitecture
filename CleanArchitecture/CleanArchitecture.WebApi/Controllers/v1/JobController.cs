using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class JobController : BaseApiController
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService) => _jobService = jobService;

        [HttpPost]
        public async Task<IActionResult> Post() =>
            Ok(await Task.Factory.StartNew(() => _jobService.FireAndForgetJob()));
    }
}
