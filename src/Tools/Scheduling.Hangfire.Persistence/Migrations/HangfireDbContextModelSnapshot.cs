﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scheduling.Infrastructure.Persistence;

#nullable disable

namespace Scheduling.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(HangfireDbContext))]
    partial class HangfireDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Scheduling.Domain.Domain.JobItems.JobItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("JobItem", "scheduling");
                });

            modelBuilder.Entity("Scheduling.Domain.Domain.Jobs.Job", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Job", "scheduling");
                });

            modelBuilder.Entity("Scheduling.Domain.Domain.JobItems.JobItem", b =>
                {
                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.FinishedOn", "FinishedOn", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("FinishedOn");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.JobId", "JobId", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("JobId");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.OutputList", "OutputList", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Json")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OutputList");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.Payload", "Payload", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Json")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Payload");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.SchedulerId", "SchedulerId", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("SchedulerId");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.StartedOn", "StartedOn", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("StartedOn");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.State", "State", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<int>("JobItemState")
                                .HasColumnType("int")
                                .HasColumnName("State");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.JobItems.ValueObjects.StoppedOn", "StoppedOn", b1 =>
                        {
                            b1.Property<long>("JobItemId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("StoppedOn");

                            b1.HasKey("JobItemId");

                            b1.ToTable("JobItem", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobItemId");
                        });

                    b.Navigation("FinishedOn");

                    b.Navigation("JobId")
                        .IsRequired();

                    b.Navigation("OutputList")
                        .IsRequired();

                    b.Navigation("Payload")
                        .IsRequired();

                    b.Navigation("SchedulerId");

                    b.Navigation("StartedOn");

                    b.Navigation("State")
                        .IsRequired();

                    b.Navigation("StoppedOn");
                });

            modelBuilder.Entity("Scheduling.Domain.Domain.Jobs.Job", b =>
                {
                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.FinishedOn", "FinishedOn", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("FinishedOn");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.JobType", "JobType", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Value")
                                .HasColumnType("BigInt")
                                .HasColumnName("JobType");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)")
                                .HasColumnName("Name");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.OutputList", "OutputList", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Json")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Payload");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.Payload", "Payload", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Json")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Payload");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.SchedulerId", "SchedulerId", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Value")
                                .HasColumnType("bigint")
                                .HasColumnName("SchedulerId");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.StartedOn", "StartedOn", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("StartedOn");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.State", "State", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<int>("JobState")
                                .HasColumnType("int")
                                .HasColumnName("State");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.OwnsOne("Scheduling.Domain.Domain.Jobs.ValueObjects.StoppedOn", "StoppedOn", b1 =>
                        {
                            b1.Property<long>("JobId")
                                .HasColumnType("bigint");

                            b1.Property<DateTimeOffset>("Value")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("StoppedOn");

                            b1.HasKey("JobId");

                            b1.ToTable("Job", "scheduling");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.Navigation("FinishedOn");

                    b.Navigation("JobType")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("OutputList")
                        .IsRequired();

                    b.Navigation("Payload")
                        .IsRequired();

                    b.Navigation("SchedulerId");

                    b.Navigation("StartedOn");

                    b.Navigation("State")
                        .IsRequired();

                    b.Navigation("StoppedOn");
                });
#pragma warning restore 612, 618
        }
    }
}
