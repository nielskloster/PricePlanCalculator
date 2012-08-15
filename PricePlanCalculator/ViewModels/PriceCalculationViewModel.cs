using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricePlanCalculator.ViewModels
{
	public class PriceCalculationViewModel
	{
		public CallType CallType { get; set; }
	}

	public enum CallType
	{
		Voice,
		Data,
		Text
	}
}