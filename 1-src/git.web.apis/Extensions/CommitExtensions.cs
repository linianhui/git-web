using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class CommitExtensions
    {
        public static CommitResponse ToResponse(this Commit @this)
        {
            return CommitResponse.From(@this);
        }

        public static CommitsResponse ToResponse(this IEnumerable<Commit> @this)
        {
            return CommitsResponse.From(@this);
        }
    }
}
