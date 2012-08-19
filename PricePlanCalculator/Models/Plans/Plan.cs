using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Plans
{
	public abstract class Plan
	{
		public Price PricePerUnit { get; private set; }

		protected Plan(Price pricePerUnit)
		{
			Check.AgainstNull(pricePerUnit, "Please provide a price for this plan.");
			PricePerUnit = pricePerUnit;
		}
	}
}