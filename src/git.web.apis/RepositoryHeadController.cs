using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/head")]
    public class RepositoryHeadController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryHeadController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_HEAD_GET)]
        public RepositoryBranchResponse GetHead(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Head
                .ToRepositoryBranchResponse()
                .WithLinks(linkProvider);
        }
    }
}
