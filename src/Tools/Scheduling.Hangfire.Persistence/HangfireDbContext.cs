using Microsoft.EntityFrameworkCore;
using Scheduling.Domain.Domain.JobItems;
using Scheduling.Domain.Domain.Jobs;
using Scheduling.Infrastructure.Persistence.Persistence.JobItems.EntityConfigurations;
using Scheduling.Infrastructure.Persistence.Persistence.Jobs.EntityConfigurations;

namespace Scheduling.Infrastructure.Persistence
{
	public class HangfireDbContext : DbContext
	{
		public HangfireDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
		}

		public DbSet<Job> Jobs { get; set; }

		public DbSet<JobItem> JobItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new JobItemEntityConfiguration());
			modelBuilder.ApplyConfiguration(new JobEntityConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
