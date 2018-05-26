using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
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

        [HttpGet(Name = Rels.GetCommits)]
        public CommitsResponse GetCommits()
        {
            var linkProvider = this.GetLinkProvider();

            return _repository.Commits
                .ToCommitsResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{commitId}", Name = Rels.GetCommitById)]
        public CommitResponse GetCommitById(string commitId)
        {
            var linkProvider = this.GetLinkProvider();

            return _repository
                .Lookup<Commit>(commitId)
                .ToCommitResponse()
                .AddLinks(linkProvider);
        }
    }
}
