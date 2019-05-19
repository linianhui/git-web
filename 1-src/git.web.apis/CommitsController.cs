using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/commits")]
    public class CommitsController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public CommitsController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetCommits)]
        public CommitsResponse GetCommits(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Commits
                .ToCommitsResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{commitId}", Name = Rels.GetCommitById)]
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
