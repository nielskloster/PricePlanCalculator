using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Plans
{
	public class VoicePlan : Plan
	{
		//Fluent setup
		public static VoicePlanIntermidate Costing(int pricePerUnit)
		{
			return new VoicePlanIntermidate(pricePerUnit);
		}
		
		public VoicePlanBillingUnit BillingUnit { get; private set; }

		internal VoicePlan(VoicePlanBillingUnit billingUnit, Price pricePerUnit)
			:base(pricePerUnit)
		{
			BillingUnit = billingUnit;
		}

		public override string ToString()
		{
			return string.Format("Voice plan costing {0} {1}", 
				PricePerUnit, 
				BillingUnit.ToString().ToPrettyCamelcase().ToLower());
		}
	}

	public class VoicePlanIntermidate
	{
		private readonly Price _pricePerUnit;

		public VoicePlanIntermidate(int pricePerUnit)
		{
			_pricePerUnit = new Price(pricePerUnit);
		}

		public VoicePlan BilledPerMinute()
		{
			return new VoicePlan(VoicePlanBillingUnit.PerMinute, _pricePerUnit);
		}

		public VoicePlan BilledPer30Seconds()
		{
			return new VoicePlan(VoicePlanBillingUnit.Per30Seconds, _pricePerUnit);
		}

		public VoicePlan BilledPerSecond()
		{
			return new VoicePlan(VoicePlanBillingUnit.PerSecond, _pricePerUnit);
		}
	}
}