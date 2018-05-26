using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet(Name = Urls.Names.GetHome)]
        public object Index()
        {
            var urls = new Urls(Url);

            return new
            {
                home_url = urls.GetHome(),
                docs_url = urls.GetHome() + ".docs",
                commits_url = urls.GetCommits()
            };
        }
    }
}
