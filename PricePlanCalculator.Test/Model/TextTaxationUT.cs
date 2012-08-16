using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class TextTaxationUT
	{
		[Test]
		public void LocalText()
		{
			var call = new TextCall(2, TestCalls.LocalCall);
			var plan = new TextPlan(4);
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(8);
		}

		[Test]
		public void LongDistance()
		{
			var call = new TextCall(2, TestCalls.LongDiscanceCall);
			var plan =new TextPlan(4);
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(12);
		}
	}
}