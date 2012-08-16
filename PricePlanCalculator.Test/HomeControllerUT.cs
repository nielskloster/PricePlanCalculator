using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using PricePlanCalculator.Controllers;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class HomeControllerUT
	{
		[Test]
		public void Index()
		{
			var controller = new HomeController();
			var result = controller.Index().As<ViewResult>();
			result.Should().NotBeNull();
			result.Model.As<PriceCalculationViewModel>().Should().NotBeNull();
		}

		[Test]
		public void CalculateCall()
		{
			var viewModel = new PriceCalculationViewModel { CallType = CallType.Voice, Units = 2 };
			var controller = new HomeController();
			var result = controller.CalculateCall(viewModel).As<PartialViewResult>();
			result.Should().NotBeNull();
			result.Model.As<int>().Should().Be(2);
		}
	}
}