namespace PricePlanCalculator.Models
{
	public class SimpleVoiceTaxation : ITaxation<VoiceCall>
	{
		public Price CalculatePrice(VoiceCall call)
		{
			if (call.IsLocal)
				return new Price(10);
			return new Price(20);
		}
	}
}