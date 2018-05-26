using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet(Name = Rels.GetHome)]
        public HomeResponse Index()
        {
            var linkProvider = new LinkProvider(Url);
            return new HomeResponse().AddLinks(linkProvider);
        }
    }
}
