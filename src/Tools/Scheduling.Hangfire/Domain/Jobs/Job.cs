using Scheduling.Domain.Domain.Helpers;
using Scheduling.Domain.Domain.Jobs.Enums;
using Scheduling.Domain.Domain.Jobs.Events;
using Scheduling.Domain.Domain.Jobs.Exceptions;
using Scheduling.Domain.Domain.Jobs.ValueObjects;

namespace Scheduling.Domain.Domain.Jobs
{
	public class Job : AggregateRoot<long>
	{
		// for impedence mismatch
		private Job() { }

		public Job(long id, Name name, JobType JobType, Payload payload, SchedulerId schedulerId)
		{
			Apply(new JobCreated(id, name.Value, JobType.Value, payload.Json, schedulerId.Value));
		}

		public void StartJob()
		{
			Apply(new JobStarted(Id, DateTime.Now));
		}

		public void StopJob()
		{
			Apply(new JobStopped(Id, DateTime.Now));
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
					Payload = new Payload(e.Payload);
					SchedulerId = new SchedulerId(e.SchedulerId);
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
				throw new InvalidEntityStateException(this, "Name cannot be null");

			if (JobType == null || JobType == default)
				throw new InvalidEntityStateException(this, "JobType cannot be null");

			if (Payload == null)
				throw new InvalidEntityStateException(this, "Payload cannot be null");

			if (SchedulerId == null)
				throw new InvalidEntityStateException(this, "SchedulerId cannot be null");

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

		public Payload Payload { get; private set; }

		public State State { get; private set; }

		public OutputList OutputList { get; private set; }

		public StartedOn? StartedOn { get; private set; }

		public StoppedOn? StoppedOn { get; private set; }

		public FinishedOn? FinishedOn { get; private set; }

		public SchedulerId? SchedulerId { get; private set; }
	}
}