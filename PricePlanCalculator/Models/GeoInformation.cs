using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models
{
	public class GeoInformation
	{
		public Coutry Origin { get; set; }
		public Coutry Destination { get; set; }

		public GeoInformation(Coutry origin, Coutry destination)
		{
			Check.AgainstNull(origin, "Country origin should not be null.");
			Check.AgainstNull(destination, "Country destination should not be null.");
			Origin = origin;
			Destination = destination;
		}

		public bool IsLocal
		{
			get { return Origin.Equals(Destination); }
		}

	}
}