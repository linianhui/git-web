using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("remotes")]
    public class RemotesController : Controller
    {
        private readonly IRepository _repository;

        public RemotesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Rels.GetRemotes)]
        public RemotesResponse GetRemotes()
        {
            var linkProvider = this.GetLinkProvider();

            return _repository
                .Network
                .Remotes
                .ToRemotesResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{remoteName}", Name = Rels.GetRemoteByName)]
        public RemoteResponse GetRemoteByName(string remoteName)
        {
            var linkProvider = this.GetLinkProvider();

            return _repository
                .FindRemote(remoteName)
                ?.ToRemoteResponse()
                .AddLinks(linkProvider);
        }
    }
}
