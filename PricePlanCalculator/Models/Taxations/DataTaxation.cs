using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public class DataTaxation : Taxation<DataCall, DataPlan>
	{
		protected override Price CalculateBasicPrice(DataCall call, DataPlan plan)
		{
			return new Price(call.BytesUsed / plan.BillingFrequencyBytes * plan.PricePerUnit.Value);
		}
	}
}