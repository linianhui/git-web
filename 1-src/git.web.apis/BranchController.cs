using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/branch")]
    public class BranchController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BranchController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetBranches)]
        public BranchListResponse GetBranchList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Branches
                .ToBranchListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}", Name = Rels.GetBranchByName)]
        public BranchResponse GetBranchByName(string repositoryName, string branchName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindBranch(branchName)
                ?.ToBranchResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}/commit", Name = Rels.GetCommitsByBranchName)]
        public CommitListResponse GetCommitListByBranchName(string repositoryName, string branchName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindBranch(branchName)
                ?.Commits
                .ToCommitListResponse()
                .AddLinks(linkProvider);
        }
    }
}
