using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/tree")]
    public class TreeController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public TreeController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{treeId}", Name = Rels.REPOSITORY_TREE_GET_BY_ID)]
        public TreeResponse GetTreeById(string repositoryName, string treeId)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Lookup<Tree>(treeId)
                .ToTreeResponse()
                .AddLinks(linkProvider);
        }
    }
}
