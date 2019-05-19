using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("blobs")]
    public class BlobsController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BlobsController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet("{blobId}", Name = Rels.GetBlobById)]
        public BlobResponse GetBlobById(string blobId)
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Lookup<Blob>(blobId)
                .ToBlobResponse()
                .AddLinks(linkProvider);
        }
    }
}
