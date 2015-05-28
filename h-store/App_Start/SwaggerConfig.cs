using System.Web.Http;
using h_store;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace h_store
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
        }
    }
}