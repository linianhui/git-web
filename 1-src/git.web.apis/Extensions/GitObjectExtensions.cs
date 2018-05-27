using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class GitObjectExtensions
    {
        public static GitObjectResponse ToGitObjectResponse(this GitObject @this)
        {
            return GitObjectResponse.From(@this);
        }

        public static List<GitObjectResponse> ToGitObjectResponses(this IEnumerable<GitObject> @this)
        {
            return GitObjectResponse.From(@this);
        }
    }
}
