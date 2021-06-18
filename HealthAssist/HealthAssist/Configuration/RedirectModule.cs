using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HealthAssist.Configuration
{
    public class RedirectModule : IHttpModule
    {
        private HttpApplication _context;
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            _context = context;
            context.MapRequestHandler += RedirectUrls;
        }
        public void RedirectUrls(object src, EventArgs args)
        {
            RedirectSection section = (RedirectSection)WebConfigurationManager.GetWebApplicationSection("redirects");
            foreach (Redirect redirect in section.Redirects)
            {
                if (redirect.Old == _context.Request.RequestContext.HttpContext.Request.RawUrl)
                {
                    _context.Response.Redirect(redirect.New);
                }
            }
        }
    }
}