namespace PricePlanCalculator.Models.Calls
{
	public class TextCall : Call
	{
		public int Units { get; private set; }

		public TextCall(GeoInformation geoInformation, int units) : base(geoInformation)
		{
			Units = units;
		}
	}
}