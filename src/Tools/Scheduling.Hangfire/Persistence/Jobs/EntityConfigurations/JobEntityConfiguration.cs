using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduling.Hangfire.Domain.Jobs;

namespace Scheduling.Hangfire.Persistence.Jobs.EntityConfigurations
{
	public class JobEntityConfiguration : IEntityTypeConfiguration<Job>
	{
		public void Configure(EntityTypeBuilder<Job> builder)
		{
			throw new NotImplementedException();
		}
	}
}
