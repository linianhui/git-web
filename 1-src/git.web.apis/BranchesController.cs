using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("branches")]
    public class BranchesController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BranchesController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetBranches)]
        public BranchesResponse GetBranches()
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Branches
                .ToBranchesResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}", Name = Rels.GetBranchByName)]
        public BranchResponse GetBranchByName(string branchName)
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .FindBranch(branchName)
                ?.ToBranchResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}/commits", Name = Rels.GetCommitsByBranchName)]
        public CommitsResponse GetCommitsByBranchName(string branchName)
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .FindBranch(branchName)
                ?.Commits
                .ToCommitsResponse()
                .AddLinks(linkProvider);
        }
    }
}
