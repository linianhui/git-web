using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/tree")]
    public class RepositoryTreeController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryTreeController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{tree_id}", Name = Rels.REPOSITORY_TREE_GET_BY_ID)]
        public RepositoryTreeResponse GetTreeById(string repository_name, string tree_id)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Lookup<Tree>(tree_id)
                .ToRepositoryTreeResponse()
                .WithLinks(linkProvider);
        }
    }
}
