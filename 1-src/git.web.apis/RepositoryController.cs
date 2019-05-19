using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}")]
    public class RepositoryController : Controller
    {
        [HttpGet(Name = Rels.REPOSITORY_HOME_GET)]
        public RepositoryResponse Index(string repositoryName)
        {
            var linkProvider = new LinkProvider(Url, repositoryName);
            return new RepositoryResponse()
                .AddLinks(linkProvider);
        }
    }
}
