using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PricePlanCalculator.Helpers;

namespace PricePlanCalculator.Models.Plans
{
	public static class StandardPlans
	{
		public static VoicePlan VoicePlan1
		{
			get { return VoicePlan.Costing(20).BilledPerMinute(); }
		}

		public static  VoicePlan VoicePlan2
		{
			get { return  VoicePlan.Costing(10).BilledPer30Seconds(); }
		}

		public static DataPlan DataPlan1
		{
			get { return new DataPlan(20, 1.Megabyte()); }
		}

		public static DataPlan DataPlan2
		{
			get { return new DataPlan(1, 100.KByte()); }
		}

		public static TextPlan TextPlan1
		{
			get { return new TextPlan(4); }
		}

		public static TextPlan TextPlan2
		{
			get { return new TextPlan(10); }
		}

		public static IEnumerable<Plan> AllPlans
		{
			get
			{
				return typeof(StandardPlans)
					.GetProperties(BindingFlags.Public | BindingFlags.Static)
					.Select(propertyInfo => propertyInfo.GetValue(null, null))
					.OfType<Plan>();
			}
		}
	}
}