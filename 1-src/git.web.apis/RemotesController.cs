using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/remotes")]
    public class RemotesController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RemotesController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetRemotes)]
        public RemotesResponse GetRemotes(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Network
                .Remotes
                .ToRemotesResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{remoteName}", Name = Rels.GetRemoteByName)]
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
