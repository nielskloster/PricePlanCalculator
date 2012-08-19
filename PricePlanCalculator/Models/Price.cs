using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models
{
	public class Price
	{
		public long Value { get; private set; }

		public Price(long value)
		{
			Check.That(() => value >= 0, "A price cannot be negative.");
			Value = value;
		}

		public static Price operator *(double p1, Price p2)
		{
			return new Price((long)(p1 * p2.Value));
		}

		public override string ToString()
		{
			return Value + " kr.";
		}
	}
}