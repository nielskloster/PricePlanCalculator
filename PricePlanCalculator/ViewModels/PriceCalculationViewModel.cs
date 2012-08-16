namespace PricePlanCalculator.ViewModels
{
	public class PriceCalculationViewModel
	{
		public CallType CallType { get; set; }
		public int Units { get; set; }
	}

	public enum CallType
	{
		VoicePlan1,
		VoicePlan2,
		DataPlan1,
		DataPlan2,
		TextPlan1,
		TextPlan2
	}
}