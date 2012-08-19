using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class StandardPlansUT
	{
		[Test]
		public void CanGetAllPlans()
		{
			StandardPlans.AllPlans.Should().HaveCount(6);
			StandardPlans.AllPlans.First().ToString().Should().Be("Voice plan costing 20 kr. per 1 minute(s)");
		}

		[Test] public void AllPlanInUiShouldBeAvailableInAStandardPlan()
		{
			foreach (var name in Enum.GetNames(typeof(PlanType)))
			{
				typeof (StandardPlans).GetProperty(name).Should().NotBeNull();
			}
			
		}
	}
}
