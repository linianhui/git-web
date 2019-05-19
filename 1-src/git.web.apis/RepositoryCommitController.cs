using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/commit")]
    public class RepositoryCommitController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryCommitController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_COMMIT_GET_LIST)]
        public CommitListResponse GetCommitList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Commits
                .ToCommitListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{commitId}", Name = Rels.REPOSITORY_COMMIT_GET_BY_ID)]
        public CommitResponse GetCommitById(string repositoryName, string commitId)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Lookup<Commit>(commitId)
                .ToCommitResponse()
                .AddLinks(linkProvider);
        }
    }
}
