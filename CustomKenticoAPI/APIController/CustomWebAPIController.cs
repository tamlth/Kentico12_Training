using CMS.Base;
using CMS.DocumentEngine;
using CMS.Membership;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomKenticoAPI.APIController
{
    public class CustomWebAPIController: ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id = 0)
        {
            // You can return a variety of things in Web API controller actions. For more details, see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            return Request.CreateResponse(HttpStatusCode.OK, new { Data = "test data", ID = id });
        }

        [HttpGet]
        public HttpResponseMessage Test(int id = 100, string name = "Default Name")
        {
            // You can return a variety of things in Web API controller actions. For more details, see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            return Request.CreateResponse(HttpStatusCode.OK, new { ID = id, Name = name });
        }

        [HttpGet]
        public HttpResponseMessage GetCourseQuantityByCourseTypeName(string courseTypeName)
        {
            TreeProvider treeProvider = new TreeProvider();
            var courseType = treeProvider.SelectNodes("Varsity.CourseType")
                .Where(p=>p.NodeName.Contains(courseTypeName));
            string result = courseType.FirstOrDefault() != null 
                ? courseType.FirstOrDefault().Children.Count.ToString() 
                : "Not found CourseType";
            return Request.CreateResponse(HttpStatusCode.OK, new { Quantity = result });
        }
    }
}
