using Scheduling.Hangfire.Domain.Helpers;
using Scheduling.Hangfire.Domain.JobItems.Enums;
using Scheduling.Hangfire.Domain.JobItems.Events;
using Scheduling.Hangfire.Domain.JobItems.Exceptions;
using Scheduling.Hangfire.Domain.JobItems.ValueObjects;

namespace Scheduling.Hangfire.Domain.JobItems
{
	// There is an important reason of defining JobItem as an aggregate root.
	public class JobItem : AggregateRoot<long>
	{
		private JobItem()
		{ }

		public JobItem(long id, JobId jobId, Payload payload, SchedulerId schedulerId)
		{
			Apply(new JobItemCreated(id, jobId.Value, payload.Json, schedulerId.Value));
		}

		public void StartJobItem()
		{
			Apply(new JobItemStarted(Id, DateTime.Now));
		}

		public void StopJobItem()
		{
			Apply(new JobItemStopped(Id, DateTime.Now));
		}

		public void FinishJobItem(State state, OutputList outputList)
		{
			Apply(new JobItemFinished(Id, state.JobItemState, outputList.Json, DateTime.Now));
		}

		protected override void When(object @event)
		{
			switch (@event)
			{
				case JobItemCreated e:
					Id = e.Id;
					JobId = new JobId(e.Id);
					Payload = new Payload(e.Payload);
					SchedulerId = new SchedulerId(e.SchedulerId);
					State = new State(JobItemState.Queued);
					break;

				case JobItemStopped e:
					State = new State(JobItemState.Stopped);
					StoppedOn = new StoppedOn(e.StoppedOn);
					break;

				case JobItemStarted e:
					State = new State(JobItemState.Stopped);
					StartedOn = new StartedOn(e.StartedOn);
					break;

				case JobItemFinished e:
					State = new State(e.JobItemState);
					FinishedOn = new FinishedOn(e.FinishedOn);
					OutputList = new OutputList(e.OutputList);
					break;
			}
		}

		protected override void EnsureValidState()
		{
			if (Id == default)
				throw new InvalidEntityStateException(this, "Id cannot be empty");

			if (JobId == null)
				throw new InvalidEntityStateException(this, "JobId cannot be null");

			if (Payload == null)
				throw new InvalidEntityStateException(this, "Payload cannot be null");

			if (SchedulerId == null)
				throw new InvalidEntityStateException(this, "SchedulerId cannot be null");

			switch (State.JobItemState)
			{
				case JobItemState.InProgress:
					if (StartedOn == null)
						throw new InvalidEntityStateException(this, "StartedOn cannot be null");
					break;

				case JobItemState.Stopped:
					if (StoppedOn == null)
						throw new InvalidEntityStateException(this, "StoppedOn cannot be null");
					break;

				case JobItemState.Success:
					if (FinishedOn == null)
						throw new InvalidEntityStateException(this, "FinishedOn cannot be null");
					break;

				case JobItemState.Failed:
					if (FinishedOn == null)
						throw new InvalidEntityStateException(this, "FinishedOn cannot be null");

					if (OutputList == null)
						throw new InvalidEntityStateException(this, "OutputList cannot be null");
					break;
			}
		}

		public JobId JobId { get; private set; }

        public Payload Payload { get; private set; }

        public State State { get; private set; }

        public OutputList OutputList { get; private set; }

        public StartedOn? StartedOn { get; private set; }

		public StoppedOn? StoppedOn { get; private set; }

		public FinishedOn? FinishedOn { get; private set; }

        public SchedulerId? SchedulerId { get; private set; }
    }
}
