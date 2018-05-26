using System;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("branches")]
    public class BranchesController : Controller
    {
        private readonly IRepository _repository;

        public BranchesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Urls.Names.GetBranches)]
        public BranchesResponse GetBranches()
        {
            var urls = new Urls(Url);

            return _repository.Branches
                .ToBranchesResponse()
                .AddLinks(urls);
        }

        [HttpGet("{branch}", Name = Urls.Names.GetBranch)]
        public BranchResponse GetBranch(string branch)
        {
            var urls = new Urls(Url);

            return FindBrach(branch)
                ?.ToBranchResponse()
                .AddLinks(urls);
        }

        [HttpGet("{branch}/commits", Name = Urls.Names.GetCommitsByBranch)]
        public CommitsResponse GetCommitsByBranch(string branch)
        {
            var urls = new Urls(Url);

            return FindBrach(branch)
                ?.Commits
                .ToCommitsResponse()
                .AddLinks(urls);

        }

        private Branch FindBrach(string branch)
        {
            if (branch == null)
            {
                return null;
            }

            branch = Uri.UnescapeDataString(branch);

            return _repository.Branches
                .FirstOrDefault(_ => _.FriendlyName == branch || _.CanonicalName == branch);
        }
    }
}
