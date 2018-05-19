using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Routes
{
    public static class Blobs
    {
        public const string GET = "blobs.get";

        public static class Links
        {
            public static string Get(IUrlHelper url, string blobId)
            {
                return url.Link(GET, new { blobId = blobId });
            }
        }
    }
}
