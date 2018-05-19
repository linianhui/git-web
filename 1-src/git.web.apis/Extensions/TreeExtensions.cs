using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class TreeExtensions
    {
        public static TreeResponse ToTreeResponse(this Tree @this)
        {
            return TreeResponse.From(@this);
        }

        public static List<TreeResponse> ToTreeResponses(this IEnumerable<Tree> @this)
        {
            return TreeResponse.From(@this);
        }
    }
}
