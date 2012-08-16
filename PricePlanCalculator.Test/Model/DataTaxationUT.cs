using NUnit.Framework;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;

namespace PricePlanCalculator.Test.Model
{
	[TestFixture]
	public class DataTaxationUT
	{
		[Test]
		public void LongDistanceCall()
		{
			var call = new DataCall(230, TestCalls.LongDiscanceCall);
			//var plan = new DataPlan(new )
		}
	}
}