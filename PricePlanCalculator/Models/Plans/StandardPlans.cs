using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Plans
{
	public static class StandardPlans
	{
		public static readonly VoicePlan VoicePlan1 = VoicePlan.Costing(20).BilledPerMinute();
		public static readonly VoicePlan VoicePlan2 = VoicePlan.Costing(10).BilledPer30Seconds();
		public static readonly DataPlan DataPlan1 = new DataPlan(20, 1.Megabyte());
		public static readonly DataPlan DataPlan2 = new DataPlan(1, 100.KByte());
		public static readonly TextPlan TextPlan1 = new TextPlan(4);
		public static readonly TextPlan TextPlan2 = new TextPlan(10);
	}
}