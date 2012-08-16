using System;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;

namespace PricePlanCalculator.Test
{
	public static class TestCalls
	{
		public static readonly CallInformation LocalCall = 
			new CallInformation(
				new GeoInformation(Coutry.Denmark, Coutry.Denmark), 
				new DateTime(2012,8,16), 
				new PhoneNumber("26836012"));

		public static readonly CallInformation LongDiscanceCall =
			new CallInformation(
				new GeoInformation(Coutry.Denmark, Coutry.Uk),
				new DateTime(2012, 8, 16),
				new PhoneNumber("26836012"));
	}
}