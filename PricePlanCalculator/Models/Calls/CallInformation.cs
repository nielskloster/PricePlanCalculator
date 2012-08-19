using System;
using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Calls
{
	public class CallInformation
	{
		public GeoInformation GeoInformation { get; private set; }
		public DateTime CallStartTime { get; private set; }
		public PhoneNumber SourcePhoneNumber { get; private set; }
		public PhoneNumber DestinationPhoneNumber { get; private set; }

		public CallInformation(GeoInformation geoInformation, DateTime callStartTime, PhoneNumber sourcePhoneNumber, PhoneNumber destinationPhoneNumber)
		{
			Check.AgainstNull(geoInformation, "Call information should include geographical information.");
			Check.AgainstNull(sourcePhoneNumber, "Call information should include a source phone number.");
			Check.AgainstNull(destinationPhoneNumber, "Call information should include a destination phone number.");
			Check.That(()=>!sourcePhoneNumber.Equals(destinationPhoneNumber), "Calling yourself is not allowed.");
			GeoInformation = geoInformation;
			CallStartTime = callStartTime;
			SourcePhoneNumber = sourcePhoneNumber;
			DestinationPhoneNumber = destinationPhoneNumber;
		}

	}
}