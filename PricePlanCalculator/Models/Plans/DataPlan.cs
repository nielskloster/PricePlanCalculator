namespace PricePlanCalculator.Models.Plans
{
	public class DataPlan : Plan
	{
		public long BillingFrequencyBytes { get; private set; }

		public DataPlan(Price pricePerUnit, long billingFrequencyBytes) : base(pricePerUnit)
		{
			BillingFrequencyBytes = billingFrequencyBytes;
		}
	}
}