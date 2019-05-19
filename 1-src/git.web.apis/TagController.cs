using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/tag")]
    public class TagController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public TagController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetTags)]
        public TagListResponse GetTagList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Tags
                .ToTagListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{tagName}", Name = Rels.GetTagByName)]
        public TagResponse GetTagByName(string repositoryName, string tagName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindTag(tagName)
                ?.ToTagResponse()
                .AddLinks(linkProvider);
        }
    }
}
