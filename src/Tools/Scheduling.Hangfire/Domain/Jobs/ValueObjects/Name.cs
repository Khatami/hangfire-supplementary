﻿using Scheduling.Hangfire.Domain.Jobs.Exceptions;

namespace Scheduling.Hangfire.Domain.Jobs.ValueObjects
{
	public record Name
	{
		private Name() { }

		public Name(string value)
		{
			if (value.Length > 1000)
				throw new JobNameOutOfRangeException();

			Value = value;
		}

		public string Value { get; private set; }

		public static implicit operator string(Name name)
		{
			return name.Value;
		}
	}
}
