﻿namespace Scheduling.Domain.Domain.Jobs.Exceptions
{
	public class JobNameOutOfRangeException : Exception
	{
		public JobNameOutOfRangeException() : base("Job Name should be less than 1000 characters")
		{ }
	}
}
