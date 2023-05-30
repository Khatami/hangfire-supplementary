using Scheduling.Hangfire.Domain.Helpers;
using Scheduling.Hangfire.Domain.Jobs.Enums;
using Scheduling.Hangfire.Domain.Jobs.Events;
using Scheduling.Hangfire.Domain.Jobs.Exceptions;
using Scheduling.Hangfire.Domain.Jobs.ValueObjects;

namespace Scheduling.Hangfire.Domain.Jobs
{
	public class Job : AggregateRoot<long>
	{
		// for impedence mismatch
		private Job() { }

		public Job(long id, Name name, JobType JobType)
		{
			Apply(new JobCreated(id, name.Value, JobType.Value));
		}

		public void StartJob()
		{
			Apply(new JobStarted(Id, DateTime.Now));
		}

		public void StopJob()
		{
			Apply(new JobStarted(Id, DateTime.Now));
		}

		public void FinishJob()
		{
			Apply(new JobFinished(Id, DateTime.Now));
		}

		protected override void When(object @event)
		{
			// Advanced Pattern Matching
			switch (@event)
			{
				case JobCreated e:
					Id = e.Id;
					Name = new Name(e.Name);
					JobType = new JobType(e.JobType);
					State = new State(JobState.Queued);
					break;

				case JobStarted e:
					State = new State(JobState.InProgress);
					StartedOn = new StartedOn(e.StartedOn);
					break;

				case JobStopped e:
					State = new State(JobState.Stopped);
					StoppedOn = new StoppedOn(e.StoppedOn);
					break;

				case JobFinished e:
					State = new State(JobState.Finished);
					FinishedOn = new FinishedOn(e.FinishedOn);
					break;
			}
		}

		protected override void EnsureValidState()
		{
			if (Id == default)
				throw new InvalidEntityStateException(this, "Id cannot be empty");

			if (Name == null || string.IsNullOrWhiteSpace(Name))
				throw new InvalidEntityStateException(this, "Name cannot be empty");

			if (JobType == null || JobType == default)
				throw new InvalidEntityStateException(this, "JobType cannot be empty");

			switch (State.JobState)
			{
				case JobState.InProgress:
					if (StartedOn == null)
						throw new InvalidEntityStateException(this, "StartedOn cannot be empty");
					break;

				case JobState.Stopped:
					if (StoppedOn == null)
						throw new InvalidEntityStateException(this, "StoppedOn cannot be empty");
					break;

				case JobState.Finished:
					if (FinishedOn == null)
						throw new InvalidEntityStateException(this, "FinishedOn cannot be empty");
					break;
			}
		}

		public JobType JobType { get; private set; }

		public Name Name { get; private set; }

		public State State { get; private set; }

		public StartedOn? StartedOn { get; private set; }

		public StoppedOn? StoppedOn { get; private set; }

		public FinishedOn? FinishedOn { get; private set; }
	}
}