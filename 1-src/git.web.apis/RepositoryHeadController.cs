using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/head")]
    public class RepositoryHeadController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryHeadController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_HEAD_GET)]
        public RepositoryBranchResponse GetHead(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Head
                .ToRepositoryBranchResponse()
                .AddLinks(linkProvider);
        }
    }
}
