using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PricePlanCalculator.Models.Calls;
using PricePlanCalculator.Models.Plans;
using PricePlanCalculator.Models.Taxations;

namespace PricePlanCalculator.Helpers
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
						   .BasedOn<IController>()
						   .LifestyleTransient());
			container.Register(Component.For<ITaxation<VoiceCall, VoicePlan>>().ImplementedBy<VoiceTaxation>());
			container.Register(Component.For<ITaxation<TextCall, TextPlan>>().ImplementedBy<TextTaxation>());
		}
	}
}