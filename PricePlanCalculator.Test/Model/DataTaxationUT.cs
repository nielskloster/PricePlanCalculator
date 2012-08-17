using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Helpers;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class DataTaxationUT
	{
		[Test]
		public void LongDistanceCall()
		{
			var call = new DataCall(2.Megabyte(), TestCalls.LongDiscanceCall);
			var plan = new DataPlan(20, 1.Megabyte());
			new DataTaxation().CalculatePrice(call, plan).Value.Should().Be(60);
		}

		[Test]
		public void LocalCall()
		{
			AssertLocalCall(2.Megabyte(), 1.Megabyte(), 40);
			AssertLocalCall(2.Megabyte(), 2.Megabyte(), 20);
			AssertLocalCall(1.Megabyte(), 1.Megabyte(), 20);
			AssertLocalCall(1025.KByte(), 1.Megabyte(), 20);
			AssertLocalCall(2047.KByte(), 1.Megabyte(), 20);
			AssertLocalCall(2048.KByte(), 1.Megabyte(), 40);
		}

		private static void AssertLocalCall(long kBytesUsed, long billingFrequencyBytes, int expectedPrice)
		{
			var call = new DataCall(kBytesUsed, TestCalls.LocalCall);
			var plan = new DataPlan(20, billingFrequencyBytes);
			new DataTaxation().CalculatePrice(call, plan).Value.Should().Be(expectedPrice);
		}
	}
}