using System;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models
{
	public class SimpleVoiceTaxation : ITaxation<VoiceCall, VoicePlan>
	{
		public Price CalculatePrice(VoiceCall call, VoicePlan plan)
		{
			var additionalCharge = call.IsLocal ? 1 : 1.5;
			return new Price((int) (CalculateBasicPrice(call, plan) * additionalCharge));
		}

		private static int CalculateBasicPrice(VoiceCall call, VoicePlan plan)
		{
			switch (plan.BillingUnit)
			{
				case VoicePlanBillingUnit.PerMinute:
					return (int) ((int) call.Duration.TotalMinutes*plan.PricePerUnit);
				case VoicePlanBillingUnit.Per30Seconds:
					return (int) ((int) call.Duration.TotalSeconds*plan.PricePerUnit);
				case VoicePlanBillingUnit.PerSecond:
					return (int) ((int) call.Duration.TotalSeconds*plan.PricePerUnit);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}