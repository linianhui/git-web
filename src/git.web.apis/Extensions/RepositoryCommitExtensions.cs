using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryCommitExtensions
    {
        public static RepositoryCommitResponse ToRepositoryCommitResponse(this Commit @this)
        {
            return RepositoryCommitResponse.From(@this);
        }

        public static List<RepositoryCommitResponse> ToRepositoryCommitResponses(this IEnumerable<Commit> @this)
        {
            return RepositoryCommitResponse.From(@this);
        }

        public static RepositoryCommitListResponse ToRepositoryCommitListResponse(this IEnumerable<Commit> @this)
        {
            return RepositoryCommitListResponse.From(@this);
        }
    }
}
