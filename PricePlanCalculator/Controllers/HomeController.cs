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

		private static Price CalculatePrice(PriceCalculationViewModel priceCalculation)
		{
			var voiceTaxation = new VoiceTaxation();
			var textTaxation = new TextTaxation();
			var geoInformation = new GeoInformation(Coutry.Denmark, Coutry.Denmark);
			var voiceCall = new VoiceCall(new TimeSpan(0, 0, priceCalculation.Units), geoInformation);
			var textCall = new TextCall(geoInformation, priceCalculation.Units);
			switch (priceCalculation.CallType)
			{
				case CallType.VoicePlan1:
					return voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan1);
				case CallType.VoicePlan2:
					return voiceTaxation.CalculatePrice(voiceCall, StandardPlans.VoicePlan2);
				case CallType.TextPlan1:
					return textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan1);
				case CallType.TextPlan2:
					return textTaxation.CalculatePrice(textCall, StandardPlans.TextPlan2);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
