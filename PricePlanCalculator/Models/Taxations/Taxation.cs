using PricePlanCalculator.Helpers;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public abstract class Taxation<TCall, TPlan> : ITaxation<TCall, TPlan> where TCall : Call where TPlan : Plan
	{
		private const double LongDistancePriceFactor = 1.5;

		public Price CalculatePrice(TCall call, TPlan plan)
		{
			Check.AgainstNull(call, "Please provide a call to calculate.");
			Check.AgainstNull(plan, "Please provide a plan for the calculation.");
			if (call.IsLocal)
				return CalculateBasicPrice(call, plan);
			return LongDistancePriceFactor*CalculateBasicPrice(call, plan);
		}

		protected abstract Price CalculateBasicPrice(TCall call, TPlan plan);
	}
}