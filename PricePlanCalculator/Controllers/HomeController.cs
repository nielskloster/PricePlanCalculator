using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PricePlanCalculator.Helpers;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;
using PricePlanCalculator.ViewModels;
using Plan = PricePlanCalculator.ViewModels.Plan;

namespace PricePlanCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITaxation<VoiceCall, VoicePlan> _voiceTaxation;
		private readonly ITaxation<TextCall, TextPlan> _textTaxation;
		private readonly ITaxation<DataCall, DataPlan> _dataTaxation;

		private readonly CallInformation _standardHardcodedCall =
			new CallInformation(
				new GeoInformation(Coutry.Denmark, Coutry.Denmark),
				new DateTime(2012, 8, 16),
				new PhoneNumber("26836012"),
				new PhoneNumber("26836013"));

		public HomeController(
			ITaxation<VoiceCall, VoicePlan> voiceTaxation,
			ITaxation<TextCall, TextPlan> textTaxation,
			ITaxation<DataCall, DataPlan> dataTaxation)
		{
			_voiceTaxation = voiceTaxation;
			_textTaxation = textTaxation;
			_dataTaxation = dataTaxation;
		}

		public ActionResult Index()
		{
			return View(new PriceCalculationViewModel());
		}

		[HttpPost]
		public ActionResult CalculateCall(PriceCalculationViewModel priceCalculation)
		{
			var price = CalculatePrice(priceCalculation);
			return PartialView("CalculationResult", price);
		}

		private Price CalculatePrice(PriceCalculationViewModel priceCalculation)
		{
			var voiceCall = new VoiceCall(new TimeSpan(0, 0, priceCalculation.Units), _standardHardcodedCall);
			var textCall = new TextCall(priceCalculation.Units, _standardHardcodedCall);
			var dataCall = new DataCall(priceCalculation.Units.KByte(), _standardHardcodedCall);
			switch (priceCalculation.Plan)
			{
				case Plan.VoicePlan1:
					return _voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan1);
				case Plan.VoicePlan2:
					return _voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan2);
				case Plan.DataPlan1:
					return _dataTaxation.CalculatePrice(dataCall, StandardPlans.DataPlan1);
				case Plan.DataPlan2:
					return _dataTaxation.CalculatePrice(dataCall, StandardPlans.DataPlan2);
				case Plan.TextPlan1:
					return _textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan1);
				case Plan.TextPlan2:
					return _textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan2);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
