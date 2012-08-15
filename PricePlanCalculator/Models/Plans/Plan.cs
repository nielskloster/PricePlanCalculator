namespace PricePlanCalculator.Models.Plans
{
	public abstract class Plan
	{
		public Price PricePerUnit { get; private set; }

		protected Plan(Price pricePerUnit)
		{
			PricePerUnit = pricePerUnit;
		}
	}

	public class TextPlan : Plan
	{
		public TextPlan(Price pricePerUnit) : base(pricePerUnit)
		{
		}
	}
}