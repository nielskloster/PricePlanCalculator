namespace PricePlanCalculator.Models
{
	public class DataCall : Call
	{
		public long BytesUsed { get; private set; }

		public DataCall(long bytesUsed, GeoInformation geoInformation) : base(geoInformation)
		{
			BytesUsed = bytesUsed;
		}
	}
}