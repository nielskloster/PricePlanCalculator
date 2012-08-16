namespace PricePlanCalculator.Models.Calls
{
	public class TextCall : Call
	{
		public int Messages { get; private set; }

		public TextCall(int messages, CallInformation callInformation) : base(callInformation)
		{
			Messages = messages;
		}
	}
}