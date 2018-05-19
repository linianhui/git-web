using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("commits")]
    public class CommitsController : Controller
    {
        private readonly IRepository _repository;

        public CommitsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Routes.Commits.GET_ALL)]
        public CommitsResponse GetCommits()
        {
            return _repository.Commits
                .ToCommitsResponse()
                .AddLinks(Url);
        }

        [HttpGet("{commitId}", Name = Routes.Commits.GET)]
        public CommitResponse GetCommit(string commitId)
        {
            return _repository
                .Lookup<Commit>(commitId)
                .ToCommitResponse()
                .AddLinks(Url);
        }
    }
}
