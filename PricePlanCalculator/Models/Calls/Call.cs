namespace PricePlanCalculator.Models.Calls
{
	public abstract class Call
	{
		private readonly GeoInformation _geoInformation;
		protected Call(GeoInformation geoInformation)
		{
			_geoInformation = geoInformation;
		}

		public bool IsLocal { get { return _geoInformation.IsLocal; } }
	}
}