using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HealthAssist.Configuration
{
    public class RedirectCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Redirect();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Redirect)element).Title;
        }
    }
}