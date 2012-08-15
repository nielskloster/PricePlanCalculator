using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Models
{
	public interface ITaxation<in TCall, in TPlan> where TCall : Call where TPlan : Plan
	{
		Price CalculatePrice(TCall call, TPlan plan);
	}
}