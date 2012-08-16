using System;

namespace PricePlanCalculator.Models.Calls
{
	public class CallInformation
	{
		public GeoInformation GeoInformation { get; private set; }
		public DateTime CallStartTime { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }
		
		public CallInformation(GeoInformation geoInformation, DateTime callStartTime, PhoneNumber phoneNumber)
		{
			GeoInformation = geoInformation;
			CallStartTime = callStartTime;
			PhoneNumber = phoneNumber;
		}

	}
}