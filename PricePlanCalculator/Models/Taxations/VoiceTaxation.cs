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
			return new Price(call.Duration.Ticks/plan.BillingFrequency.Ticks*plan.PricePerUnit.Value);
		}
	}
}