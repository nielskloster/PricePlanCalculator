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
			new GeoInformation(Coutry.Denmark, Coutry.Denmark).IsLocal.Should().BeTrue();
			new GeoInformation(Coutry.Denmark, Coutry.Uk).IsLocal.Should().BeFalse();
		}
	}
}
