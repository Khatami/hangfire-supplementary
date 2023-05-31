namespace Scheduling.Domain.Domain.JobItems.ValueObjects
{
	public record SchedulerId
	{
		private SchedulerId() { }

		public SchedulerId(long? value)
		{
			if (value == null || value == default)
				throw new ArgumentNullException(nameof(value));

			Value = value.Value;
		}

		public long Value { get; set; }
	}
}
