using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public abstract class Taxation<TCall, TPlan> : ITaxation<TCall, TPlan> where TCall : Call where TPlan : Plan
	{
		private const double LongDistancePriceFactor = 1.5;

		public Price CalculatePrice(TCall call, TPlan plan)
		{
			if (call.IsLocal)
				return CalculateBasicPrice(call, plan);
			return LongDistancePriceFactor*CalculateBasicPrice(call, plan);
		}

		protected abstract Price CalculateBasicPrice(TCall call, TPlan plan);
	}
}