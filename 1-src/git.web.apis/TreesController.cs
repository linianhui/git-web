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
        private readonly IRepository _repository;

        public TreesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{treeId}", Name = Rels.GetTreeById)]
        public TreeResponse GetTreeById(string treeId)
        {
            var linkProvider = new LinkProvider(Url);

            return _repository
                .Lookup<Tree>(treeId)
                .ToTreeResponse()
                .AddLinks(linkProvider);
        }
    }
}
