using h_store.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;


namespace h_store.Controllers.Api
{
    public class TokenController : ApiController
    {
        private bool CheckXSRFToken(string tokenFromHeader)
        {
            string cookieToken = null;
            CookieHeaderValue clientCookie = null;
            clientCookie = Request.Headers.GetCookies
                                    ("XSRF-TOKEN").SingleOrDefault();

            cookieToken = (clientCookie != null) ? clientCookie["XSRF-TOKEN"].Value : null;
            
            try
            {
                AntiForgery.Validate(cookieToken, tokenFromHeader);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        [HttpGet]
        
        public HttpResponseMessage token(string assertion)
        {
            User user = null;
            if (!(CheckXSRFToken(assertion))) 
         
            {
                HttpError err = new HttpError("Bad token for validation");
                return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
            }

            if((user = (User)(System.Web.HttpContext.Current.Session["user"])) == null){
                {
                    HttpError err = new HttpError("User not logged in");
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
                }
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string issuer = "00000000-0000-0000-0000-000000000000";
            string audience = "https://hypothes.is";
            

            IEnumerable<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>{
                new System.Security.Claims.Claim("userId",user.username),
                new System.Security.Claims.Claim("consumerKey","00000000-0000-0000-0000-000000000000"),
                new System.Security.Claims.Claim("ttl","3600"),
                new System.Security.Claims.Claim("issuedAt",DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")),
                new System.Security.Claims.Claim("sub", user.username)

            };

            Lifetime lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10));
            SecurityKey securityKey = new InMemorySymmetricSecurityKey(System.Text.ASCIIEncoding.UTF8.GetBytes("00000000-0000-0000-0000-000000000000"));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,
                "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                "http://www.w3.org/2001/04/xmlenc#sha256");
            JwtSecurityToken jwt = new JwtSecurityToken(issuer, audience, claims, DateTime.Now, DateTime.Now.AddSeconds(3600), signingCredentials);

            return Request.CreateResponse(HttpStatusCode.OK, tokenHandler.WriteToken(jwt));
        }


    }
}
