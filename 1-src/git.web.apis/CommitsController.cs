using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using IGitRepository = LibGit2Sharp.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("commits")]
    public class CommitsController : Controller
    {
        private readonly IGitRepository _gitRepository;

        public CommitsController(IGitRepository gitRepository)
        {
            _gitRepository = gitRepository;
        }

        [HttpGet(Name = Routes.Commits.GET_ALL)]
        public CommitsResponse GetCommits()
        {
            return _gitRepository.Commits
                .ToResponse()
                .AddLinks(Url);
        }

        [HttpGet("{commitId}", Name = Routes.Commits.GET)]
        public CommitResponse GetCommit(string commitId)
        {
            return _gitRepository
                .Lookup<Commit>(commitId)
                .ToResponse()
                .AddLinks(Url);
        }
    }
}
