using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/branches")]
    public class BranchesController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BranchesController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetBranches)]
        public BranchesResponse GetBranches(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Branches
                .ToBranchesResponse()
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

        [HttpGet("{branchName}/commits", Name = Rels.GetCommitsByBranchName)]
        public CommitsResponse GetCommitsByBranchName(string repositoryName, string branchName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindBranch(branchName)
                ?.Commits
                .ToCommitsResponse()
                .AddLinks(linkProvider);
        }
    }
}
