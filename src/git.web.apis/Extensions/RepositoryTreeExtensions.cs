using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryTreeExtensions
    {
        public static RepositoryTreeResponse ToRepositoryTreeResponse(this Tree @this)
        {
            return RepositoryTreeResponse.From(@this);
        }

        public static List<RepositoryTreeResponse> ToRepositoryTreeResponses(this IEnumerable<Tree> @this)
        {
            return RepositoryTreeResponse.From(@this);
        }
    }
}
