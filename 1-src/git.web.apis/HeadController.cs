using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("head")]
    public class HeadController : Controller
    {
        private readonly IRepository _repository;

        public HeadController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Rels.GetHead)]
        public BranchResponse GetHead()
        {
            var linkProvider = this.GetLinkProvider();

            return _repository
                .Head
                .ToBranchResponse()
                .AddLinks(linkProvider);
        }
    }
}
