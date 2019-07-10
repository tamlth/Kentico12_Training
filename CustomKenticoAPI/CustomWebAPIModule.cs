using CMS;
using CMS.DataEngine;
using System.Web.Http;

// Registers the custom module into the system
[assembly: RegisterModule(typeof(CustomKenticoAPI.CustomWebAPIModule))]

namespace CustomKenticoAPI
{
    public class CustomWebAPIModule : Module
    {
        // Module class constructor, the system registers the module under the name "CustomWebAPI"
        public CustomWebAPIModule()
        : base("CustomWebAPI")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            // Registers a "customapi" route
            GlobalConfiguration.Configuration.Routes.MapHttpRoute("customapi", "customapi/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
