namespace PricePlanCalculator.Models
{
	public class Price
	{
		public int Value { get; private set; }

		public Price(int value)
		{
			Value = value;
		}

		public static Price operator *(Price p1, Price p2)
		{
			return new Price(p1.Value*p2.Value);
		}

		public static Price operator *(int p1, Price p2)
		{
			return new Price(p1*p2.Value);
		}

		public static Price operator *(double p1, Price p2)
		{
			return new Price((int)(p1 * p2.Value));
		}

		public override string ToString()
		{
			return Value + " kr.";
		}
	}
}