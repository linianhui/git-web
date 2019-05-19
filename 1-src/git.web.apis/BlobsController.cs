using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/{repositoryName}/blobs")]
    public class BlobsController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BlobsController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{blobId}", Name = Rels.GetBlobById)]
        public BlobResponse GetBlobById(string repositoryName, string blobId)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Lookup<Blob>(blobId)
                .ToBlobResponse()
                .AddLinks(linkProvider);
        }
    }
}
