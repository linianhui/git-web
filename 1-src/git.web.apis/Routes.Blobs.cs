using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    public static partial class Routes
    {
        public static class Blobs
        {
            public const string GET = "blobs.get";

            public static class Links
            {
                public static string Get(IUrlHelper url, string blobId)
                {
                    return url.Link(GET, new {blob_id = blobId});
                }
            }
        }
    }
}
