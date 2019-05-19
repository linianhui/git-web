using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryBlobResponse : LinkResponse<RepositoryBlobResponse>
    {
        private RepositoryBlobResponse()
        {
        }

        public string id { get; private set; }

        public long size { get; private set; }

        public bool is_binary { get; private set; }

        public string content_text { get; private set; }

        public override RepositoryBlobResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetBlobById(id));
            return this;
        }

        public static RepositoryBlobResponse From(Blob blob)
        {
            var blobResponse = new RepositoryBlobResponse
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

        public static List<RepositoryBlobResponse> From(IEnumerable<Blob> blobs)
        {
            return blobs.Select(From).ToList();
        }
    }
}
