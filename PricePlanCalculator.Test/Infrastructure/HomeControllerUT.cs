using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PricePlanCalculator.Controllers;
using PricePlanCalculator.Models;
using PricePlanCalculator.Services;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Test.Infrastructure
{
	[TestFixture]
	public class HomeControllerUT
	{
		[Test]
		public void ControllerDepenenciesAreSatisfied()
		{
			var container = new WindsorContainer().Install(FromAssembly.Containing<HomeController>());
			container.Resolve<HomeController>();
		}

		[Test]
		public void Index()
		{
			var calculationService = new Mock<IPriceCalculationService>();
			var controller = new HomeController(calculationService.Object);
			var result = controller.Index().As<ViewResult>();
			result.Should().NotBeNull();
			result.Model.As<PriceCalculationViewModel>().Should().NotBeNull();
		}

		[Test]
		public void CalculateCall()
		{
			var calculationService = new Mock<IPriceCalculationService>();
			var viewModel = new PriceCalculationViewModel { PlanType = PlanType.VoicePlan1 };
			calculationService.Setup(x => x.CalculatePrice(It.IsAny<PriceCalculationViewModel>())).Returns(new Price(10));
			var controller = new HomeController(calculationService.Object);
			var result = controller.CalculateCall(viewModel).As<PartialViewResult>();
			result.Should().NotBeNull();
			result.Model.As<Price>().Value.Should().Be(10);
		}
	}
}