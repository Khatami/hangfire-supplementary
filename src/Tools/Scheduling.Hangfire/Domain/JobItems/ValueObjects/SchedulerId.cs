namespace Scheduling.Domain.Domain.JobItems.ValueObjects
{
	public record SchedulerId
	{
		private SchedulerId() { }

		public SchedulerId(string value)
		{
			if (string.IsNullOrEmpty(value) == false)
				throw new ArgumentNullException(nameof(value));

			Value = value;
		}

		public string Value { get; set; }
	}
}
