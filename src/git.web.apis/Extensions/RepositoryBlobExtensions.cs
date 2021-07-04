using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryBlobExtensions
    {
        public static RepositoryBlobResponse ToRepositoryBlobResponse(this Blob @this)
        {
            return RepositoryBlobResponse.From(@this);
        }

        public static List<RepositoryBlobResponse> ToRepositoryBlobResponses(this IEnumerable<Blob> @this)
        {
            return RepositoryBlobResponse.From(@this);
        }
    }
}
