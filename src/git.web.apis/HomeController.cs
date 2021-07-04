using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public HomeController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.HOME_GET)]
        public HomeResponse Index()
        {
            var repositoryNames = _repositoryFactory.GetRepositoryNames();
            var linkProvider = new LinkProvider(Url, null);
            return new HomeResponse(repositoryNames)
                .WithLinks(linkProvider);
        }
    }
}
