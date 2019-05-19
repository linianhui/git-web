using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/remote")]
    public class RemoteController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RemoteController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_REMOTE_GET_LIST)]
        public RemoteListResponse GetRemoteList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Network
                .Remotes
                .ToRemoteListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{remoteName}", Name = Rels.REPOSITORY_REMOTE_GET_BY_NAME)]
        public RemoteResponse GetRemoteByName(string repositoryName, string remoteName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindRemote(remoteName)
                ?.ToRemoteResponse()
                .AddLinks(linkProvider);
        }
    }
}
