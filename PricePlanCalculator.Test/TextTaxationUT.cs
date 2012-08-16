using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class TextTaxationUT
	{
		[Test]
		public void LocalText()
		{
			var geoInformation = new GeoInformation(Coutry.Denmark, Coutry.Denmark);
			var call = new TextCall(geoInformation, 2);
			var plan = new TextPlan(4);
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(8);
		}

		[Test]
		public void LongDistance()
		{
			var geoInformation = new GeoInformation(Coutry.Uk, Coutry.Denmark);
			var call = new TextCall(geoInformation, 2);
			var plan =new TextPlan(4);
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(12);
		}
	}
}