namespace PricePlanCalculator.Models
{
	public class GeoInformation
	{
		public Coutry From { get; set; }
		public Coutry To { get; set; }

		public GeoInformation(Coutry from, Coutry to)
		{
			From = from;
			To = to;
		}

		public bool IsLocal
		{
			get { return From.Equals(To); }
		}

	}
}