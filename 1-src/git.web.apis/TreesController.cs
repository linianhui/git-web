using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("trees")]
    public class TreesController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public TreesController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{treeId}", Name = Rels.GetTreeById)]
        public TreeResponse GetTreeById(string treeId)
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Lookup<Tree>(treeId)
                .ToTreeResponse()
                .AddLinks(linkProvider);
        }
    }
}
