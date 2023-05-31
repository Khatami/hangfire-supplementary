using Microsoft.EntityFrameworkCore;
using Scheduling.Hangfire.Domain.JobItems;
using Scheduling.Hangfire.Domain.Jobs;
using Scheduling.Hangfire.Persistence.Persistence.JobItems.EntityConfigurations;
using Scheduling.Hangfire.Persistence.Persistence.Jobs.EntityConfigurations;

namespace Scheduling.Hangfire.Persistence
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
