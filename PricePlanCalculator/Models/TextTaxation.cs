using System;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models
{
	public class TextTaxation : ITaxation<Text, TextPlan>
	{
		public Price CalculatePrice(Text call, TextPlan plan)
		{
			var additionalCharge = call.IsLocal ? 1 : 1.5;
			return additionalCharge * plan.PricePerUnit;
		}
	}
}