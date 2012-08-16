namespace PricePlanCalculator.Models.Plans
{
	public static class StandardPlans
	{
		public static readonly VoicePlan VoicePlan1 = VoicePlan.Costing(20).BilledPerMinute();
		public static readonly VoicePlan VoicePlan2 = VoicePlan.Costing(10).BilledPer30Seconds();
		public static readonly TextPlan TextPlan1 = new TextPlan(4);
		public static readonly TextPlan TextPlan2 = new TextPlan(10);
	}
}