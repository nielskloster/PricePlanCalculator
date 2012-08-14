using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class GeoInformationUT
	{
		[Test]
		public void IsLocal()
		{
			var denmark = new Coutry("Denmark");
			var uk = new Coutry("Uk");
			new GeoInformation(denmark, denmark).IsLocal.Should().BeTrue();
			new GeoInformation(denmark, uk).IsLocal.Should().BeFalse();
		}
	}
}
