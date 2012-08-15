namespace PricePlanCalculator.Models.Plans
{
	public class VoicePlan : Plan
	{
		#region FluentPlanSetup
		public static VoicePlanIntermidate BilledPerMinute()
		{
			return new VoicePlanIntermidate(VoicePlanBillingUnit.PerMinute);
		}

		public static VoicePlanIntermidate BilledPer30Seconds()
		{
			return new VoicePlanIntermidate(VoicePlanBillingUnit.Per30Seconds);
		}

		public static VoicePlanIntermidate BilledPerSecond()
		{
			return new VoicePlanIntermidate(VoicePlanBillingUnit.PerSecond);
		}

		public class VoicePlanIntermidate
		{
			private readonly VoicePlanBillingUnit _billingUnit;

			public VoicePlanIntermidate(VoicePlanBillingUnit billingUnit)
			{
				_billingUnit = billingUnit;
			}

			public VoicePlan Costing(int pricePerUnit)
			{
				return new VoicePlan(_billingUnit, new Price(pricePerUnit));
			}
		}
		#endregion
		
		public VoicePlanBillingUnit BillingUnit { get; private set; }

		private VoicePlan(VoicePlanBillingUnit billingUnit, Price pricePerUnit)
			:base(pricePerUnit)
		{
			BillingUnit = billingUnit;
		}
	}
}