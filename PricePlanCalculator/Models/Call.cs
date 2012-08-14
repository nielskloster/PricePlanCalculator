using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricePlanCalculator.Models
{
	public abstract class Call
	{
		private GeoInformation GeoInformation { get; set; }

		protected Call(GeoInformation geoInformation)
		{
			GeoInformation = geoInformation;
		}
	}

	public class VoiceCall : Call
	{
		public VoiceCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}

	public class DataCall : Call
	{
		public DataCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}

	public class TextCall : Call
	{
		public TextCall(GeoInformation geoInformation) : base(geoInformation)
		{
		}
	}

	public interface IPricingStrategy<T> where T:Call
	{
		Price CalculatePrice(T call);
	}

	public class Price
	{
		public int Value { get; private set; }

		public Price(int value)
		{
			Value = value;
		}
	}
}