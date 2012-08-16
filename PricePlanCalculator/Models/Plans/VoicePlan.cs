using System;
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
		
		public TimeSpan BillingFrequency { get; private set; }

		internal VoicePlan(TimeSpan billingFrequency, Price pricePerUnit)
			:base(pricePerUnit)
		{
			BillingFrequency = billingFrequency;
		}

		public override string ToString()
		{
			return string.Format("Voice plan costing {0} per {1}", 
				PricePerUnit, 
				BillingFrequency.ToReadableString());
		}
	}
}