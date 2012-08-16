namespace PricePlanCalculator.Models.Plans
{
	public class TextPlan : Plan
	{
		public TextPlan(int pricePerUnit)
			: base(new Price(pricePerUnit))
		{
		}

		public override string ToString()
		{
			return string.Format("Text plan costing {0} per message", PricePerUnit);
		}
	}
}