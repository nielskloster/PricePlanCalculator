using System;

namespace PricePlanCalculator.Helpers
{
	public static class Check
	{
		public static void That(Func<bool> clause, string message)
		{
			if (!clause.Invoke())
				throw new InvalidOperationException(message);
		}

		public static void AgainstNull(object value, string message)
		{
			if (value == null)
				throw new NullReferenceException(message);
		}

		public static void AgainstNull(string value, string message)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new NullReferenceException(message);
		}
	}
}