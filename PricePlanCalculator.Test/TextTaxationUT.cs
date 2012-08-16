using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;
using Text = PricePlanCalculator.Models.Calls.Text;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class TextTaxationUT
	{
		[Test]
		public void LocalText()
		{
			var geoInformation = new GeoInformation(Coutry.Denmark, Coutry.Denmark);
			var call = new Text(geoInformation);
			var plan = new TextPlan(new Price(4));
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(4);
		}

		[Test]
		public void LongDistance()
		{
			var geoInformation = new GeoInformation(Coutry.Uk, Coutry.Denmark);
			var call = new Text(geoInformation);
			var plan =new TextPlan(new Price(4));
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(6);
		}
	}
}