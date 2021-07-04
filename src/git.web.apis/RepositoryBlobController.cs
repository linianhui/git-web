using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/blob")]
    public class RepositoryBlobController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryBlobController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{blob_id}", Name = Rels.REPOSITORY_BLOB_GET_BY_ID)]
        public RepositoryBlobResponse GetBlobById(string repository_name, string blob_id)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Lookup<Blob>(blob_id)
                .ToRepositoryBlobResponse()
                .WithLinks(linkProvider);
        }
    }
}
