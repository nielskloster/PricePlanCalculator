namespace PricePlanCalculator.Models
{
	public class Price
	{
		public int Value { get; private set; }

		public Price(int value)
		{
			Value = value;
		}
	}
}