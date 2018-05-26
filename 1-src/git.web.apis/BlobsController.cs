using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
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

        [HttpGet("{blob_id}", Name = Urls.Names.GetBlobById)]
        public BlobResponse GetTree([FromRoute(Name = "blob_id")]string blobId)
        {
            var urls = new Urls(Url);

            return _repository
                .Lookup<Blob>(blobId)
                .ToBlobResponse()
                .AddLinks(urls);
        }
    }
}
