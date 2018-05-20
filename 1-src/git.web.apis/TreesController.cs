using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("trees")]
    public class TreesController : Controller
    {
        private readonly IRepository _repository;

        public TreesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{tree_id}", Name = Routes.Trees.GET)]
        public TreeResponse GetTree([FromRoute(Name = "tree_id")]string treeId)
        {
            return _repository
                .Lookup<Tree>(treeId)
                .ToTreeResponse()
                .AddLinks(Url);
        }
    }
}
