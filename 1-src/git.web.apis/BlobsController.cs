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
        private readonly IRepository _repository;

        public BlobsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{blobId}", Name = Blobs.GET)]
        public BlobResponse GetTree(string blobId)
        {
            return _repository
                .Lookup<Blob>(blobId)
                .ToBlobResponse()
                .AddLinks(Url);
        }
    }
}
