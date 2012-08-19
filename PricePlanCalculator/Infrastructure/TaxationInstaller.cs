using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;
using PricePlanCalculator.Services;

namespace PricePlanCalculator.Infrastructure
{
	public class TaxationInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ITaxation<VoiceCall, VoicePlan>>().ImplementedBy<VoiceTaxation>());
			container.Register(Component.For<ITaxation<TextCall, TextPlan>>().ImplementedBy<TextTaxation>());
			container.Register(Component.For<ITaxation<DataCall, DataPlan>>().ImplementedBy<DataTaxation>());
			container.Register(Component.For<IPriceCalculationService>().ImplementedBy<PriceCalculationService>());
		}
	}
}