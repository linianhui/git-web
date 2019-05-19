using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}")]
    public class RepositoryController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_GET)]
        public RepositoryResponse Get(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return new RepositoryResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("clone", Name = Rels.REPOSITORY_CLONE)]
        public RepositoryResponse Clone(string repositoryName, [FromQuery] string repositoryUrl)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            _repositoryFactory.CloneRepository(repositoryName, repositoryUrl);

            return new RepositoryResponse()
                .AddLinks(linkProvider);
        }
    }
}
