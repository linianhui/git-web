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

        [HttpGet("{blobId}", Name = Urls.Names.GetBlob)]
        public BlobResponse GetTree(string blobId)
        {
            var urls = new Urls(Url);

            return _repository
                .Lookup<Blob>(blobId)
                .ToBlobResponse()
                .AddLinks(urls);
        }
    }
}
