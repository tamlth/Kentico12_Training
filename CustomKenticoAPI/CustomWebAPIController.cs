using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomKenticoAPI
{
    public class CustomWebAPIController: ApiController
    {
        public HttpResponseMessage Get(int id = 0)
        {
            // You can return a variety of things in Web API controller actions. For more details, see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            return Request.CreateResponse(HttpStatusCode.OK, new { Data = "test data", ID = id });
        }

        [HttpGet]
        public HttpResponseMessage Test(int id = 100)
        {
            // You can return a variety of things in Web API controller actions. For more details, see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            return Request.CreateResponse(HttpStatusCode.OK, new { Data = "test data", ID = id });
        }
    }
}
