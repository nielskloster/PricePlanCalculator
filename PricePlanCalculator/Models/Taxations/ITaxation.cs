using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models.Taxations
{
	public interface ITaxation<in TCall, in TPlan> where TCall : Call where TPlan : Plan
	{
		Price CalculatePrice(TCall call, TPlan plan);
	}
}