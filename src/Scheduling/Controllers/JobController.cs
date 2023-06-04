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
			long jobId = 1;
			string jobName = "For testing scheduling";
			string payload = string.Empty;

			_jobService.CreateJobAsync<JobController>(jobId, (int)JobType.BulkInsert, jobName, q => q.Do(12), payload);

			return Ok();
		}

		[NonAction]
		public void Do(long id)
		{

		}
	}

	public enum JobType
	{ 
		BulkInsert,
		BulkUpdate,
		BulkDelete
	}
}
