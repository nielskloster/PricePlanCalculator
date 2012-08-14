using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class BasicVoiceTaxationUT
	{
		[Test]
		public void LocalCall()
		{
			var denmark = new Coutry("Denmark");
			new SimpleVoiceTaxation()
				.CalculatePrice(new VoiceCall(new GeoInformation(denmark, denmark)))
				.Value
				.Should().Be(10);
		}

		[Test]
		public void LongDistance()
		{
			var denmark = new Coutry("Denmark");
			var uk = new Coutry("Uk");

			new SimpleVoiceTaxation()
				.CalculatePrice(new VoiceCall(new GeoInformation(uk, denmark)))
				.Value
				.Should().Be(20);
		}
	}
}