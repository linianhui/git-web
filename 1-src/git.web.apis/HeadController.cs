using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("head")]
    public class HeadController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public HeadController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetHead)]
        public BranchResponse GetHead()
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Head
                .ToBranchResponse()
                .AddLinks(linkProvider);
        }
    }
}
