using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace h_store.Controllers
{
    public class SessionStateRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }  
}