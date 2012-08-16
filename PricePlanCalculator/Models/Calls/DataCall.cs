namespace PricePlanCalculator.Models.Calls
{
	public class DataCall : Call
	{
		public long BytesUsed { get; private set; }

		public DataCall(long bytesUsed, CallInformation callInformation) : base(callInformation)
		{
			BytesUsed = bytesUsed;
		}
	}
}