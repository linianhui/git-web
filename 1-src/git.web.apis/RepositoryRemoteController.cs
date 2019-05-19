using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/remote")]
    public class RepositoryRemoteController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryRemoteController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_REMOTE_GET_LIST)]
        public RepositoryRemoteListResponse GetRemoteList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Network
                .Remotes
                .ToRepositoryRemoteListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{remoteName}", Name = Rels.REPOSITORY_REMOTE_GET_BY_NAME)]
        public RepositoryRemoteResponse GetRemoteByName(string repositoryName, string remoteName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindRemote(remoteName)
                ?.ToRepositoryRemoteResponse()
                .AddLinks(linkProvider);
        }
    }
}
