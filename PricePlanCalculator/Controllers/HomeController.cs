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
using PricePlanCalculator.Services;
using PricePlanCalculator.ViewModels;

namespace PricePlanCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPriceCalculationService _calculationService;

		public HomeController(
			IPriceCalculationService calculationService)
		{
			_calculationService = calculationService;
		}

		public ActionResult Index()
		{
			return View(new PriceCalculationViewModel());
		}

		[HttpPost]
		public ActionResult CalculateCall(PriceCalculationViewModel priceCalculation)
		{
			var price = _calculationService.CalculatePrice(priceCalculation);
			return PartialView("CalculationResult", price);
		}
	}
}
