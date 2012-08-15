using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Plans;
using Text = PricePlanCalculator.Models.Text;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class TextTaxationUT
	{
		[Test]
		public void LocalText()
		{
			var denmark = new Coutry("Denmark");
			var geoInformation = new GeoInformation(denmark, denmark);
			var call = new Text(geoInformation);
			var plan = new TextPlan(new Price(4));
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(4);
		}

		[Test]
		public void LongDistance()
		{
			var geoInformation = new GeoInformation(new Coutry("Uk"), new Coutry("Denmark"));
			var call = new Text(geoInformation);
			var plan =new TextPlan(new Price(4));
			new TextTaxation()
				.CalculatePrice(call, plan)
				.Value.Should().Be(6);
		}
	}
}