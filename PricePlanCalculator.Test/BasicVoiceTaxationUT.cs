using System;
using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class BasicVoiceTaxationUT
	{
		[Test]
		public void LocalCall()
		{
			var denmark = new Coutry("Denmark");
			var call = new VoiceCall(new TimeSpan(0,0,1,0), new GeoInformation(denmark, denmark));
			var plan = VoicePlan.BilledPerMinute().Costing(4);
			new SimpleVoiceTaxation()
				.CalculatePrice(call, plan)
				.Value
				.Should().Be(4);
		}

		[Test]
		public void LongDistance()
		{
			var geoInformation = new GeoInformation(new Coutry("Uk"), new Coutry("Denmark"));
			var call = new VoiceCall(new TimeSpan(0, 0, 1, 0), geoInformation);
			var plan = VoicePlan.BilledPerMinute().Costing(4);
			new SimpleVoiceTaxation()
				.CalculatePrice(call, plan)
				.Value
				.Should().Be(6);
		}

		[TestCase(0,1,0, 4)]
		[TestCase(0,1,1, 4)]
		[TestCase(1,0,0, 240)]
		public void BilledPerMinute(int hours, int minutes, int seconds, int expectedPrice)
		{
			var denmark = new Coutry("Denmark");
			var call = new VoiceCall(new TimeSpan(0, hours, minutes, seconds), new GeoInformation(denmark, denmark));
			var plan = VoicePlan.BilledPerMinute().Costing(4);
			new SimpleVoiceTaxation()
				.CalculatePrice(call, plan)
				.Value
				.Should().Be(expectedPrice);
		}
	}
}