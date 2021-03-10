using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterBundles()
        {
            var builder = new ContainerBuilder();

            // registers all controllers as MvcApplication is the project in the code behind the project
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // builder to know about the type and then use the type when IRestaurantData is implemented
            builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>()
                   .SingleInstance();

            //build container
            var container = builder.Build();
            //class to set dependecys using the autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                    
        }
    }
}