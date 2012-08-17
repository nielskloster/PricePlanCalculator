using System;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public class VoiceTaxation : Taxation<VoiceCall, VoicePlan>
	{
		protected override Price CalculateBasicPrice(VoiceCall call, VoicePlan plan)
		{
			return new Price(call.Duration.Ticks/plan.BillingFrequency.Ticks*plan.PricePerUnit.Value);
		}
	}
}