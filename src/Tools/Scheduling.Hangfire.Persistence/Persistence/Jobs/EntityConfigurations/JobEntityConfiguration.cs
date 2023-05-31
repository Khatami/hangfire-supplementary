using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduling.Domain.Domain.Jobs;
using System.Data;

namespace Scheduling.Infrastructure.Persistence.Persistence.Jobs.EntityConfigurations
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

			builder.OwnsOne(x => x.Payload, x =>
			{
				x.Property(e => e.Json)
					.HasColumnName(nameof(Job.Payload))
					.IsRequired();
			});

			builder.OwnsOne(x => x.State, x =>
			{
				x.Property(e => e.JobState)
					.HasColumnName(nameof(Job.State))
					.IsRequired();
			});

			builder.OwnsOne(x => x.OutputList, x =>
			{
				x.Property(e => e.Json)
					.HasColumnName(nameof(Job.Payload))
					.IsRequired();
			});

			builder.OwnsOne(x => x.StartedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(Job.StartedOn));
			});

			builder.OwnsOne(x => x.StoppedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(Job.StoppedOn));
			});

			builder.OwnsOne(x => x.FinishedOn, x =>
			{
				x.Property(e => e.Value)
					.HasColumnType("datetimeoffset")
					.HasColumnName(nameof(Job.FinishedOn));
			});

			builder.OwnsOne(x => x.SchedulerId, x =>
			{
				x.Property(e => e.Value)
					.HasColumnName(nameof(Job.SchedulerId));
			});

			builder.ToTable(nameof(Job), "scheduling");
		}
	}
}
