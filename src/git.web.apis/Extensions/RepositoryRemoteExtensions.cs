using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryRemoteExtensions
    {
        public static RepositoryRemoteResponse ToRepositoryRemoteResponse(this Remote @this)
        {
            return RepositoryRemoteResponse.From(@this);
        }

        public static List<RepositoryRemoteResponse> ToRepositoryRemoteResponses(this IEnumerable<Remote> @this)
        {
            return RepositoryRemoteResponse.From(@this);
        }

        public static List<RepositoryRefSpecResponse> ToRepositoryRefSpecResponses(this IEnumerable<RefSpec> @this)
        {
            return RepositoryRefSpecResponse.From(@this);
        }

        public static RepositoryRemoteListResponse ToRepositoryRemoteListResponse(this IEnumerable<Remote> @this)
        {
            return RepositoryRemoteListResponse.From(@this);
        }
    }
}
