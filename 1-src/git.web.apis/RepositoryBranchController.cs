using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/branch")]
    public class RepositoryBranchController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryBranchController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_BRANCH_GET_LIST)]
        public RepositoryBranchListResponse GetBranchList(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Branches
                .ToRepositoryBranchListResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}", Name = Rels.REPOSITORY_BRANCH_GET_BY_NAME)]
        public RepositoryBranchResponse GetBranchByName(string repositoryName, string branchName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindBranch(branchName)
                ?.ToRepositoryBranchResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{branchName}/commit", Name = Rels.REPOSITORY_COMMIT_GET_LIST_BY_BRANCH_NAME)]
        public RepositoryCommitListResponse GetCommitListByBranchName(string repositoryName, string branchName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .FindBranch(branchName)
                ?.Commits
                .ToRepositoryCommitListResponse()
                .AddLinks(linkProvider);
        }
    }
}
