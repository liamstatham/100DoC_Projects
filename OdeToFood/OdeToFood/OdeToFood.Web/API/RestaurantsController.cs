using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.API
{
    public class RestaurantsController : ApiController
    {
        public string get()
        {
            return "Hello, world! this is my first get request";
        }
    }
}
