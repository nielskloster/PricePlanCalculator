using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class GeoInformationUT
	{
		[Test]
		public void IsLocal()
		{
			new GeoInformation(Coutry.Denmark, Coutry.Denmark).IsLocal.Should().BeTrue();
			new GeoInformation(Coutry.Denmark, Coutry.Uk).IsLocal.Should().BeFalse();
		}
	}
}
