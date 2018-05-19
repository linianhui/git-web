using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public object Index()
        {
            return new
            {
                commits_url = Routes.Commits.Links.GetAll(Url)
            };
        }
    }
}
