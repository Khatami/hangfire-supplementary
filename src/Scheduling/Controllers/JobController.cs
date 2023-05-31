using Microsoft.AspNetCore.Mvc;
using Scheduling.Application.Jobs.IServices;

namespace Scheduling.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private readonly IJobService _jobService;

		public JobController(IJobService jobService)
		{
			_jobService = jobService;
		}

		[HttpGet(nameof(RunJobs))]
		public ActionResult RunJobs()
		{
			_jobService.CreateJobAsync<JobController>(12, 12, "BulkInsert", "Today.csv", q => q.Do(12), null);

			return Ok();
		}

		[NonAction]
		public void Do(long id)
		{

		}
	}
}
