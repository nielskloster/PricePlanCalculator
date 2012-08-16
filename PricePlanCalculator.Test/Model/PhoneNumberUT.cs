using System;
using NUnit.Framework;
using PricePlanCalculator.Models.Calls;

namespace PricePlanCalculator.Test.Model
{
	
	[TestFixture]
	public class PhoneNumberUT
	{
		[Test]
		public void BasicValidation()
		{
			Assert.Throws<InvalidOperationException>(()=>new PhoneNumber("lfjgdf"));
			Assert.DoesNotThrow(() => new PhoneNumber("26836012"));
		}
	}
}
