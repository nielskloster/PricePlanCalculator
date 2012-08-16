using System;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public class VoiceTaxation : ITaxation<VoiceCall, VoicePlan>
	{
		public Price CalculatePrice(VoiceCall call, VoicePlan plan)
		{
			var additionalCharge = call.IsLocal ? 1 : 1.5;
			return additionalCharge * CalculateBasicPrice(call, plan);
		}

		private static Price CalculateBasicPrice(VoiceCall call, VoicePlan plan)
		{
			switch (plan.BillingUnit)
			{
				case VoicePlanBillingUnit.PerMinute:
					return (int)call.Duration.TotalMinutes*plan.PricePerUnit;
				case VoicePlanBillingUnit.Per30Seconds:
					return (int)(call.Duration.TotalSeconds / 30) * plan.PricePerUnit;
				case VoicePlanBillingUnit.PerSecond:
					return (int)call.Duration.TotalSeconds*plan.PricePerUnit;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}