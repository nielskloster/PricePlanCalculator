namespace PricePlanCalculator.Models
{
	public interface ITaxation<T> where T:Call
	{
		Price CalculatePrice(T call);
	}
}