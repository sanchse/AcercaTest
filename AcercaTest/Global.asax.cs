using AcercaTest.Services.Core;
using AcercaTest.Services.Services;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AcercaTest {
  public class WebApiApplication : System.Web.HttpApplication {
    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      Autofac_Configuration();
    }

    private void Autofac_Configuration() {
      var builder = new ContainerBuilder();

      // Get your HttpConfiguration.
      var config = GlobalConfiguration.Configuration;

      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

      builder.RegisterType<CredentialsValidationService>().As<ICredendialsValidationService>();
      builder.RegisterType<VehiclesService>().As<IVehiclesService>();
      builder.RegisterType<Services.Vehicles.FileVehicleRepository>().As<IRepository<Services.Vehicles.Vehicle>>();
      builder.RegisterType<Services.Vehicles.FileVehicleRepository>()
       .As<IRepository<Services.Vehicles.Vehicle>>()
       .WithParameter("baseFilePath", Config.Config.GetBaseFilePath());

      builder.RegisterWebApiFilterProvider(config);

      // Set the dependency resolver to be Autofac.
      var container = builder.Build();
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}