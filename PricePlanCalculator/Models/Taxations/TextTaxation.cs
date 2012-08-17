using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public class TextTaxation : Taxation<TextCall, TextPlan>
	{
		protected override Price CalculateBasicPrice(TextCall call, TextPlan plan)
		{
			return call.Messages * plan.PricePerUnit;
		}
	}
}