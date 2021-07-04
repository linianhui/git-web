using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryTreeEntryExtensions
    {
        public static RepositoryTreeEntryResponse ToRepositoryTreeEntryResponse(this TreeEntry @this)
        {
            return RepositoryTreeEntryResponse.From(@this);
        }

        public static List<RepositoryTreeEntryResponse> ToRepositoryTreeEntryResponses(this IEnumerable<TreeEntry> @this)
        {
            return RepositoryTreeEntryResponse.From(@this);
        }
    }
}
