using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/tag")]
    public class RepositoryTagController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryTagController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_TAG_GET_LIST)]
        public RepositoryTagListResponse GetTagList(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Tags
                .ToRepositoryTagListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{tag_name}", Name = Rels.REPOSITORY_TAG_GET_BY_NAME)]
        public RepositoryTagResponse GetTagByName(string repository_name, string tag_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .FindTag(tag_name)
                ?.ToRepositoryTagResponse()
                .AddLinks(linkProvider);
        }
    }
}
