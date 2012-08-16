using System;
using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class VoiceTaxationUT
	{
		[Test]
		public void LongDistance()
		{
			var call = new VoiceCall(new TimeSpan(0, 0, 1, 0), TestCalls.LongDiscanceCall);
			var plan = VoicePlan.BilledPerMinute().Costing(4);
			new VoiceTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(6);
		}

		[TestCase(0,1,0, 4)]
		[TestCase(0,1,33, 4)]
		[TestCase(1,1,1, 244)]
		[TestCase(1,0,0, 240)]
		public void BilledPerMinute(int hours, int minutes, int seconds, int expectedPrice)
		{
			var call = new VoiceCall(new TimeSpan(0, hours, minutes, seconds), TestCalls.LocalCall);
			var plan = VoicePlan.BilledPerMinute().Costing(4);
			new VoiceTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(expectedPrice);
		}

		[TestCase(0, 0, 33, 4)]
		[TestCase(0, 1, 33, 12)]
		[TestCase(1, 1, 1, 488)]
		[TestCase(1, 0, 0, 480)]
		public void BilledPer30Seconds(int hours, int minutes, int seconds, int expectedPrice)
		{
			var call = new VoiceCall(new TimeSpan(0, hours, minutes, seconds), TestCalls.LocalCall);
			var plan = VoicePlan.BilledPer30Seconds().Costing(4);
			new VoiceTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(expectedPrice);
		}

		[TestCase(0, 0, 33, 66)]
		[TestCase(0, 1, 33, 186)]
		[TestCase(1, 1, 1, 7322)]
		[TestCase(1, 0, 0, 7200)]
		public void BilledPerSecond(int hours, int minutes, int seconds, int expectedPrice)
		{
			var call = new VoiceCall(new TimeSpan(0, hours, minutes, seconds), TestCalls.LocalCall);
			var plan = VoicePlan.BilledPerSecond().Costing(2);
			new VoiceTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(expectedPrice);
		}
	}
}