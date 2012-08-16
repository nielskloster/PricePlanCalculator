namespace PricePlanCalculator.Models.Plans
{
	public static class StandardPlans
	{
		public static readonly VoicePlan VoicePlan1 = VoicePlan.BilledPerMinute().Costing(20);
		public static readonly VoicePlan VoicePlan2 = VoicePlan.BilledPer30Seconds().Costing(10);
		public static readonly TextPlan TextPlan1 = new TextPlan(4);
		public static readonly TextPlan TextPlan2 = new TextPlan(10);
	}
}