using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/tag")]
    public class RepositoryTagController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryTagController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_TAG_GET_LIST)]
        public TagListResponse GetTagList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Tags
                .ToTagListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{tagName}", Name = Rels.REPOSITORY_TAG_GET_BY_NAME)]
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
