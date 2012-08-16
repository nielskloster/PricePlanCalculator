using System;

namespace PricePlanCalculator.Models.Plans
{
	public class VoicePlanIntermidate
	{
		private readonly Price _pricePerUnit;

		public VoicePlanIntermidate(int pricePerUnit)
		{
			_pricePerUnit = new Price(pricePerUnit);
		}

		public VoicePlan BilledPerMinute()
		{
			return new VoicePlan(new TimeSpan(0, 1, 0), _pricePerUnit);
		}

		public VoicePlan BilledPer30Seconds()
		{
			return new VoicePlan(new TimeSpan(0, 0, 30), _pricePerUnit);
		}

		public VoicePlan BilledPerSecond()
		{
			return new VoicePlan(new TimeSpan(0, 0, 1), _pricePerUnit);
		}
	}
}