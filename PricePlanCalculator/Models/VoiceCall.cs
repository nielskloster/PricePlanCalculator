using System;

namespace PricePlanCalculator.Models
{
	public class VoiceCall : Call
	{
		public TimeSpan Duration { get; private set; }

		public VoiceCall(TimeSpan duration, GeoInformation geoInformation) : base(geoInformation)
		{
			Duration = duration;
		}
	}
}