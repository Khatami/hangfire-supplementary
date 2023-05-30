using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduling.Hangfire.Domain.JobItems;

namespace Scheduling.Hangfire.Persistence.JobItems.EntityConfigurations
{
	public class JobItemEntityConfiguration : IEntityTypeConfiguration<JobItem>
	{
		public void Configure(EntityTypeBuilder<JobItem> builder)
		{
			throw new NotImplementedException();
		}
	}
}
