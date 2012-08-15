using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricePlanCalculator.Models
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