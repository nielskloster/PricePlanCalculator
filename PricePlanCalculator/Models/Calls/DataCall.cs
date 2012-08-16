namespace PricePlanCalculator.Models.Calls
{
	public class DataCall : Call
	{
		public long KBytesUsed { get; private set; }

		public DataCall(long kBytesUsed, CallInformation callInformation) : base(callInformation)
		{
			KBytesUsed = kBytesUsed;
		}
	}
}