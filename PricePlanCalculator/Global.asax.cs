using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PricePlanCalculator.App_Start;
using PricePlanCalculator.Helpers;

namespace PricePlanCalculator
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new WindsorContainer().Install(FromAssembly.This());
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
		}
	}
}