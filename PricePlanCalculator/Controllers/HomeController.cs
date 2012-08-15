using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
		public ActionResult CalculateCall()
		{
			return PartialView("CalculationResult", 10);
		}
	}
}
