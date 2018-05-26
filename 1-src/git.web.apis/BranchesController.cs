using System;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
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

        [HttpGet(Name = Rels.GetBranches)]
        public BranchesResponse GetBranches()
        {
            var linkProvider = this.GetLinkProvider();

            return _repository.Branches
                .ToBranchesResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}", Name = Rels.GetBranchByName)]
        public BranchResponse GetBranchByName(string branchName)
        {
            var linkProvider = this.GetLinkProvider();

            return FindBrach(branchName)
                ?.ToBranchResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}/commits", Name = Rels.GetCommitsByBranchName)]
        public CommitsResponse GetCommitsByBranchName(string branchName)
        {
            var linkProvider = this.GetLinkProvider();

            return FindBrach(branchName)
                ?.Commits
                .ToCommitsResponse()
                .AddLinks(linkProvider);
        }

        private Branch FindBrach(string branchName)
        {
            if (branchName == null)
            {
                return null;
            }

            branchName = Uri.UnescapeDataString(branchName);

            return _repository.Branches
                .FirstOrDefault(_ => _.FriendlyName == branchName || _.CanonicalName == branchName);
        }
    }
}
