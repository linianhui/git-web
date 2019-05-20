using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/remote")]
    public class RepositoryRemoteController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryRemoteController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_REMOTE_GET_LIST)]
        public RepositoryRemoteListResponse GetRemoteList(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Network
                .Remotes
                .ToRepositoryRemoteListResponse()
                .WithLinks(linkProvider);
        }

        [HttpGet("{remote_name}", Name = Rels.REPOSITORY_REMOTE_GET_BY_NAME)]
        public RepositoryRemoteResponse GetRemoteByName(string repository_name, string remote_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .FindRemote(remote_name)
                ?.ToRepositoryRemoteResponse()
                .WithLinks(linkProvider);
        }
    }
}
