using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Membership;
using CMS.Search;
using CustomKenticoAPI.Model;
using Newtonsoft.Json;

namespace CustomKenticoAPI.APIController
{
    public class SmartSearchAPIController: ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id = 0)
        {
            // You can return a variety of things in Web API controller actions. For more details, see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            return Request.CreateResponse(HttpStatusCode.OK, new { Data = "test data", ID = id });
        }
        [HttpGet]
        public HttpResponseMessage GetSearchResult
            (
            string searchIndexes,
            string searchText,
            string cultureCode = null,
            int pageNumber = 1,
            int pageSize = 10,
            bool combineWithDefaultCulture = true
            )
        {
            SearchParameters searchParameters = 
                SearchParameters.PrepareForPages(
                    searchText, new List<string>{ searchIndexes }, pageNumber, pageSize, 
                    MembershipContext.AuthenticatedUser, cultureCode, combineWithDefaultCulture);
            var result = SearchHelper.Search(searchParameters).Items
                .Select(p => new SearchResultItemModel
                {
                    Content = p.Content,
                    Created = p.Created,
                    DocumentExtensions = p.DocumentExtensions,
                    Id = p.Id,
                    Image = p.Image,
                    Index = p.Index,
                    MaxScore = p.MaxScore,
                    Position = p.Position,
                    Score = p.Score,
                    Title = p.Title,
                    Type = p.Type
                }).ToList();
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
