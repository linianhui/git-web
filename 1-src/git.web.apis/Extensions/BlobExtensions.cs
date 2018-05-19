using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class BlobExtensions
    {
        public static BlobResponse ToBlobResponse(this Blob @this)
        {
            return BlobResponse.From(@this);
        }

        public static List<BlobResponse> ToBlobResponses(this IEnumerable<Blob> @this)
        {
            return BlobResponse.From(@this);
        }
    }
}
