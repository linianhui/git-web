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

        [HttpGet(Name = Urls.Names.GetCommits)]
        public CommitsResponse GetCommits()
        {
            var urls = new Urls(Url);

            return _repository.Commits
                .ToCommitsResponse()
                .AddLinks(urls);
        }

        [HttpGet("{commit_id}", Name = Urls.Names.GetCommitById)]
        public CommitResponse GetCommitById([FromRoute(Name = "commit_id")]string commitId)
        {
            var urls = new Urls(Url);

            return _repository
                .Lookup<Commit>(commitId)
                .ToCommitResponse()
                .AddLinks(urls);
        }
    }
}
