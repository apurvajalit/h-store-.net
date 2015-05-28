using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace h_store.Controllers.Api
{
    public class CheckAuthFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }
            if (System.Web.HttpContext.Current.Session["userID"] == "")
            {
                //return actionContext.Request.CreateResponse(HttpStatusCode.NotAcceptable, err)
               // return new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }

            base.OnActionExecuting(actionContext);
           
        }
    }
    
    
}