using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("tags")]
    public class TagsController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public TagsController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetTags)]
        public TagsResponse GetTags()
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Tags
                .ToTagsResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{tagName}", Name = Rels.GetTagByName)]
        public TagResponse GetTagByName(string tagName)
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .FindTag(tagName)
                ?.ToTagResponse()
                .AddLinks(linkProvider);
        }
    }
}
