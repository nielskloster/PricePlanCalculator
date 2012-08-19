using System;
using System.Text.RegularExpressions;

namespace PricePlanCalculator.Models
{
	public class PhoneNumber
	{
		public string NumberString { get; private set; }
		
		public PhoneNumber(string numberString)
		{
			var regex = new Regex("[0-9]{8}");
			if (!regex.IsMatch(numberString))
			{
				throw new InvalidOperationException(string.Format("The phone number {0} is not valid. It should contain 8 numeric characters. Ex. 26836012", numberString));
			}
			NumberString = numberString;
		}

		public bool Equals(PhoneNumber other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.NumberString, NumberString);
		}

	}
}