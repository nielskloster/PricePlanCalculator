using System;

namespace PricePlanCalculator.Models.Calls
{
	public abstract class Call
	{
		public GeoInformation GeoInformation { get; private set; }
		public DateTime CallStartTime { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }

		protected Call(CallInformation callInformation)
		{
			GeoInformation = callInformation.GeoInformation;
			CallStartTime = callInformation.CallStartTime;
			PhoneNumber = callInformation.PhoneNumber;
		}

		public bool IsLocal { get { return GeoInformation.IsLocal; } }
	}
}