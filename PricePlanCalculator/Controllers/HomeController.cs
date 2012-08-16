using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PricePlanCalculator.Models;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITaxation<VoiceCall, VoicePlan> _voiceTaxation;
		private readonly ITaxation<TextCall, TextPlan> _textTaxation;

		private readonly  CallInformation _standardHardcodedCall = 
			new CallInformation(
				new GeoInformation(Coutry.Denmark, Coutry.Denmark), 
				new DateTime(2012,8,16), 
				new PhoneNumber("26836012"));

		public HomeController(ITaxation<VoiceCall, VoicePlan> voiceTaxation, ITaxation<TextCall, TextPlan> textTaxation )
		{
			_voiceTaxation = voiceTaxation;
			_textTaxation = textTaxation;
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
			switch (priceCalculation.CallType)
			{
				case CallType.VoicePlan1:
					return _voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan1);
				case CallType.VoicePlan2:
					return _voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan2);
				case CallType.TextPlan1:
					return _textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan1);
				case CallType.TextPlan2:
					return _textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan2);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
