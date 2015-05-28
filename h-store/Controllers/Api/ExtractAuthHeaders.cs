using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Filters;

namespace h_store.Controllers.Api
{
    public class ExtractAuthHeaders : ActionFilterAttribute
    {
        string[] headerParameters = { "XSRF-TOKEN", "session", "X-Client-Id", "X-Annotator-Auth-Token"};
        void setHeaderValueIfAvailable(string name, HttpRequestHeaders header, IDictionary<string, object> properties)
        {
            IEnumerable<string> temp = null;

            if (header.TryGetValues(name, out temp))
                properties[name] = temp.First<string>();
           
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            foreach (var property in headerParameters)
                setHeaderValueIfAvailable(property, 
                    actionContext.Request.Headers, 
                    actionContext.Request.Properties);

            
        }
    }
}