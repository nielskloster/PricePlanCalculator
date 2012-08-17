namespace PricePlanCalculator.Models.Calls
{
	public class DataCall : Call
	{
		public long BytesUsed { get; private set; }

		public DataCall(long kBytesUsed, CallInformation callInformation) : base(callInformation)
		{
			BytesUsed = kBytesUsed;
		}
	}
}