using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class BlobResponse : LinksResponse<BlobResponse>
    {
        private BlobResponse() { }

        public string id { get; private set; }

        public long size { get; private set; }

        public bool is_binary { get; private set; }

        public string content_text { get; private set; }

        public static BlobResponse From(Blob blob)
        {
            var blobResponse = new BlobResponse
            {
                id = blob.Sha,
                size = blob.Size,
                is_binary = blob.IsBinary
            };
            if (blobResponse.is_binary == false)
            {
                blobResponse.content_text = blob.GetContentText();
            }
            return blobResponse;
        }

        public static List<BlobResponse> From(IEnumerable<Blob> blobs)
        {
            return blobs.Select(From).ToList();
        }

        public override BlobResponse AddLinks(IUrlHelper url)
        {
            AddSelf(Blobs.Links.Get(url, id));
            return this;
        }
    }
}
