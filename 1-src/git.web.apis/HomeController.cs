using Microsoft.AspNetCore.Http.Extensions;
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
                home_url = base.Request.GetDisplayUrl()
            };
        }
    }
}
