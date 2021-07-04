using Git.Web.Apis.Extensions;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/branch")]
    public class RepositoryBranchController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryBranchController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_BRANCH_GET_LIST)]
        public RepositoryBranchListResponse GetBranchList(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Branches
                .ToRepositoryBranchListResponse()
                .WithLinks(linkProvider);
        }

        [HttpGet("{branch_name}", Name = Rels.REPOSITORY_BRANCH_GET_BY_NAME)]
        public RepositoryBranchResponse GetBranchByName(string repository_name, string branch_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .FindBranch(branch_name)
                ?.ToRepositoryBranchResponse()
                .WithLinks(linkProvider);
        }

        [HttpGet("{branch_name}/commit", Name = Rels.REPOSITORY_COMMIT_GET_LIST_BY_BRANCH_NAME)]
        public RepositoryCommitListResponse GetCommitListByBranchName(string repository_name, string branch_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .FindBranch(branch_name)
                ?.Commits
                .ToRepositoryCommitListResponse()
                .WithLinks(linkProvider);
        }
    }
}
