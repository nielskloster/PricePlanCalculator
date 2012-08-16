using System;
using System.Text.RegularExpressions;

namespace PricePlanCalculator.Models.Calls
{
	public class PhoneNumber
	{
		public string NumberString { get; private set; }

		public PhoneNumber(string numberString)
		{
			var regex = new Regex("[0-9]{8}");
			if (!regex.IsMatch(numberString))
			{
				throw new InvalidOperationException(string.Format("The phone number {0} is not valid. It should contain only 8 characters.", numberString));
			}
			NumberString = numberString;
		}
	}
}