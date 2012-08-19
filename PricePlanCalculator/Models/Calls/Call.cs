using System;
using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Calls
{
	public abstract class Call
	{
		public GeoInformation GeoInformation { get; private set; }
		public DateTime CallStartTime { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }

		protected Call(CallInformation callInformation)
		{
			Check.AgainstNull(callInformation, "Please provide call information.");
			GeoInformation = callInformation.GeoInformation;
			CallStartTime = callInformation.CallStartTime;
			PhoneNumber = callInformation.SourcePhoneNumber;
		}

		public bool IsLocal { get { return GeoInformation.IsLocal; } }
	}
}