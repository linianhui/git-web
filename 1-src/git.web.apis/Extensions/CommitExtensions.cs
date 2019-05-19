using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class CommitExtensions
    {
        public static CommitResponse ToCommitResponse(this Commit @this)
        {
            return CommitResponse.From(@this);
        }

        public static List<CommitResponse> ToCommitResponses(this IEnumerable<Commit> @this)
        {
            return CommitResponse.From(@this);
        }

        public static CommitListResponse ToCommitListResponse(this IEnumerable<Commit> @this)
        {
            return CommitListResponse.From(@this);
        }
    }
}
