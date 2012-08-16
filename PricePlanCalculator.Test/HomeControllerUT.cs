using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PricePlanCalculator.Controllers;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Test
{
	[TestFixture]
	public class HomeControllerUT
	{
		[Test]
		public void Index()
		{
			var voiceTaxation = new Mock<ITaxation<VoiceCall, VoicePlan>>();
			var textTaxation = new Mock<ITaxation<TextCall, TextPlan>>();
			var controller = new HomeController(voiceTaxation.Object, textTaxation.Object);
			var result = controller.Index().As<ViewResult>();
			result.Should().NotBeNull();
			result.Model.As<PriceCalculationViewModel>().Should().NotBeNull();
		}

		[Test]
		public void CalculateCall()
		{
			var voiceTaxation = new Mock<ITaxation<VoiceCall, VoicePlan>>();
			voiceTaxation.Setup(x => x.CalculatePrice(It.IsAny<VoiceCall>(), It.IsAny<VoicePlan>())).Returns(new Price(10));
			var textTaxation = new Mock<ITaxation<TextCall, TextPlan>>();
			var viewModel = new PriceCalculationViewModel { CallType = CallType.VoicePlan1, Units = 65 };
			var controller = new HomeController(voiceTaxation.Object, textTaxation.Object);
			var result = controller.CalculateCall(viewModel).As<PartialViewResult>();
			result.Should().NotBeNull();
			result.Model.As<Price>().Value.Should().Be(10);
		}
	}
}