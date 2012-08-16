namespace PricePlanCalculator.ViewModels
{
	public class PriceCalculationViewModel
	{
		public CallType CallType { get; set; }
		public int Units { get; set; }
	}

	public enum CallType
	{
		Voice,
		Data,
		Text
	}
}