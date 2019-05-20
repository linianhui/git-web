using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/commit")]
    public class RepositoryCommitController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryCommitController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_COMMIT_GET_LIST)]
        public RepositoryCommitListResponse GetCommitList(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Commits
                .ToRepositoryCommitListResponse()
                .WithLinks(linkProvider);
        }

        [HttpGet("{commit_id}", Name = Rels.REPOSITORY_COMMIT_GET_BY_ID)]
        public RepositoryCommitResponse GetCommitById(string repository_name, string commit_id)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Lookup<Commit>(commit_id)
                .ToRepositoryCommitResponse()
                .WithLinks(linkProvider);
        }
    }
}
