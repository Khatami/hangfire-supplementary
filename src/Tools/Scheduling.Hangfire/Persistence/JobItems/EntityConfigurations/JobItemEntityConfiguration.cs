using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduling.Hangfire.Domain.JobItems;
using System.Data;

namespace Scheduling.Hangfire.Persistence.JobItems.EntityConfigurations
{
	public class JobItemEntityConfiguration : IEntityTypeConfiguration<JobItem>
	{
		public void Configure(EntityTypeBuilder<JobItem> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).ValueGeneratedNever();

			builder.OwnsOne(x => x.JobId, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(JobItem.JobId))
					.HasColumnType(SqlDbType.BigInt.ToString())
					.IsRequired();
			});

			builder.OwnsOne(x => x.Payload, x =>
			{
				x.Property(e => e.Json)
					.HasColumnName(nameof(JobItem.Payload))
					.IsRequired();
			});

			builder.OwnsOne(x => x.State, x =>
			{
				x.Property(e => e.JobItemState)
					.HasColumnName(nameof(JobItem.State))
					.IsRequired();
			});

			builder.OwnsOne(x => x.OutputList, x =>
			{
				x.Property(e => e.Json)
					.HasColumnName(nameof(JobItem.OutputList));
			});

			builder.OwnsOne(x => x.StartedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(JobItem.StartedOn));
			});

			builder.OwnsOne(x => x.StoppedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(JobItem.StoppedOn));
			});

			builder.OwnsOne(x => x.FinishedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(JobItem.FinishedOn));
			});

			builder.OwnsOne(x => x.SchedulerId, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(JobItem.SchedulerId));
			});
		}
	}
}
