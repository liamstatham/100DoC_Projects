using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Jims_Cars.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Jims_Cars.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterBundles(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            // registers all controllers as MvcApplication is the project in the code behind the project
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            // builder to know about the type and then use the type when ICarData is implemented
            builder.RegisterType<SqlCarData>()
                   .As<ICarData>()
                   .InstancePerRequest();
            builder.RegisterType<CarsDbContext>().InstancePerRequest();
            

            //build container
            var container = builder.Build();
            //class to set dependecys using the autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}