using FluentAssertions;
using NUnit.Framework;

namespace PricePlanCalculator.Test.Infrastructure
{
	[TestFixture]
	public class BootStrapUT
	{
		[Test]
		public void FluentAssertionsAreWorking()
		{
			"Fluent".Should().Be("Fluent");
		}
	}
}
