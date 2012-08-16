using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
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