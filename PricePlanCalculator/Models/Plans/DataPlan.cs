using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Plans
{
	public class DataPlan : Plan
	{
		public long BillingFrequencyBytes { get; private set; }

		public DataPlan(int pricePerUnit, long billingFrequencyBytes) : base(new Price(pricePerUnit))
		{
			BillingFrequencyBytes = billingFrequencyBytes;
		}

		public override string ToString()
		{
			return string.Format("Data plan costing {0} per {1}", PricePerUnit, BillingFrequencyBytes.ToFormattedDataSize());
		}
	}
}