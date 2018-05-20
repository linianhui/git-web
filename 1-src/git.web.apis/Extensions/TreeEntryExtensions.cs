using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class TreeEntryExtensions
    {
        public static TreeEntryResponse ToTreeEntryResponse(this TreeEntry @this)
        {
            return TreeEntryResponse.From(@this);

        }

        public static TreeEntryTargetResponse ToTreeEntryTargetResponse(this TreeEntry @this)
        {
            return TreeEntryTargetResponse.From(@this);
        }

        public static List<TreeEntryResponse> ToTreeEntryResponses(this IEnumerable<TreeEntry> @this)
        {
            return TreeEntryResponse.From(@this);
        }
    }
}
