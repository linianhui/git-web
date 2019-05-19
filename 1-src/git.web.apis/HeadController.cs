using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/head")]
    public class HeadController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public HeadController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetHead)]
        public BranchResponse GetHead(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Head
                .ToBranchResponse()
                .AddLinks(linkProvider);
        }
    }
}
