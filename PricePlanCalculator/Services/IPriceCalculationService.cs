using PricePlanCalculator.Models;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Services
{
	public interface IPriceCalculationService
	{
		Price CalculatePrice(PriceCalculationViewModel priceCalculation);
	}
}