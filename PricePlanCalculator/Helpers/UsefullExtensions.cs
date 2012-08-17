using System;

namespace PricePlanCalculator.Helpers
{
	public static class UsefullExtensions
	{
		public static string ToReadableString(this TimeSpan span)
		{
			var formatted = String.Format("{0}{1}{2}{3}",
			                              span.Days > 0 ? String.Format("{0:0} days, ", span.Days) : String.Empty,
			                              span.Hours > 0 ? String.Format("{0:0} hours, ", span.Hours) : String.Empty,
			                              span.Minutes > 0 ? String.Format("{0:0} minute(s), ", span.Minutes) : String.Empty,
			                              span.Seconds > 0 ? String.Format("{0:0} second(s)", span.Seconds) : String.Empty);

			if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

			return formatted;
		}

		public static long KByte(this int kByte)
		{
			return kByte*1024;
		}

		public static long Megabyte(this int megabyte)
		{
			return megabyte * 1024 * 1024;
		}
	}
}