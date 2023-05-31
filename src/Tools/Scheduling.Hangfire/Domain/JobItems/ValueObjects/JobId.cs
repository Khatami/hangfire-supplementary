namespace Scheduling.Hangfire.Domain.Domain.JobItems.ValueObjects
{
	public record JobId
	{
		private JobId() { }

		public JobId(long? value)
		{
			if (value == null || value == default)
				throw new ArgumentNullException(nameof(value));

			Value = value.Value;
		}

		public long Value { get; set; }
	}
}
