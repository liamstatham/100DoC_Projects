using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HealthAssist
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new ParameterControllerFactory());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            Debug.WriteLine("Begin Request");
        }
        protected void Application_MapRequestHandler()
        {
            Debug.WriteLine("Map Handler");
        }
        protected void Application_PostMapRequestHandler()
        {
            Debug.WriteLine("Post map handler");
        }
        protected void Application_AquireRequestState()
        {
            Debug.WriteLine("Request state");
        }
        protected void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("Pre handler execute");
        }
        protected void Application_PostRequestHandlerExecute()
        {
            Debug.WriteLine("Post handler execute");
        }
        protected void Application_EndRequest()
        {
            Debug.WriteLine("End Request");
        }
    }
}
