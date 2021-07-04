using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}")]
    public class RepositoryController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_GET)]
        public RepositoryResponse Get(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return new RepositoryResponse()
                .WithLinks(linkProvider);
        }

        [HttpGet("clone", Name = Rels.REPOSITORY_CLONE)]
        public RepositoryResponse Clone(string repository_name, [FromQuery] string repository_url)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            _repositoryFactory.CloneRepository(repository_name, repository_url);

            return new RepositoryResponse()
                .WithLinks(linkProvider);
        }
    }
}
