using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RemoteExtensions
    {
        public static RemoteResponse ToRemoteResponse(this Remote @this)
        {
            return RemoteResponse.From(@this);
        }

        public static List<RemoteResponse> ToRemoteResponses(this IEnumerable<Remote> @this)
        {
            return RemoteResponse.From(@this);
        }

        public static List<RefSpecResponse> ToRefSpecResponses(this IEnumerable<RefSpec> @this)
        {
            return RefSpecResponse.From(@this);
        }

        public static RemoteListResponse ToRemoteListResponse(this IEnumerable<Remote> @this)
        {
            return RemoteListResponse.From(@this);
        }
    }
}
