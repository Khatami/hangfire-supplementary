using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduling.Hangfire.Domain.JobItems;
using Scheduling.Hangfire.Domain.Jobs;
using System.Data;

namespace Scheduling.Hangfire.Persistence.Persistence.Jobs.EntityConfigurations
{
	public class JobEntityConfiguration : IEntityTypeConfiguration<Job>
	{
		public void Configure(EntityTypeBuilder<Job> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).ValueGeneratedNever();

			builder.OwnsOne(x => x.JobType, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(Job.JobType))
					.HasColumnType(SqlDbType.BigInt.ToString())
					.IsRequired();
			});

			builder.OwnsOne(x => x.Name, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(Job.Name))
					.HasMaxLength(1000)
					.IsRequired();
			});

			builder.OwnsOne(x => x.State, x =>
			{
				x.Property(e => e.JobState)
					.HasColumnName(nameof(Job.State))
					.IsRequired();
			});

			builder.OwnsOne(x => x.State, x =>
			{
				x.Property(e => e.JobState)
					.HasColumnName(nameof(Job.State))
					.IsRequired();
			});

			builder.OwnsOne(x => x.StartedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(JobItem.StartedOn));
			});

			builder.OwnsOne(x => x.StoppedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(JobItem.StoppedOn));
			});

			builder.OwnsOne(x => x.FinishedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(JobItem.FinishedOn));
			});

			builder.ToTable(nameof(Job), "scheduling");
		}
	}
}
