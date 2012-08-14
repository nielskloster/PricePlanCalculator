using System;
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

	public class VoiceCall : Call
	{
		public VoiceCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}

	public class DataCall : Call
	{
		public DataCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}

	public class TextCall : Call
	{
		public TextCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}
}