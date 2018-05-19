using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class GitObjectExtensions
    {
        public static IdResponse ToIdResponse(this GitObject @this)
        {
            return IdResponse.From(@this);
        }

        public static List<IdResponse> ToIdResponses(this IEnumerable<GitObject> @this)
        {
            return IdResponse.From(@this);
        }
    }
}
