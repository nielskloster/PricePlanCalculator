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
		public TimeSpan Duration { get; private set; }

		public VoiceCall(TimeSpan duration, GeoInformation geoInformation) : base(geoInformation)
		{
			Duration = duration;
		}
	}

	public class DataCall : Call
	{
		public long BytesUsed { get; private set; }

		public DataCall(long bytesUsed, GeoInformation geoInformation) : base(geoInformation)
		{
			BytesUsed = bytesUsed;
		}
	}

	public class TextCall : Call
	{
		public TextCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}
}