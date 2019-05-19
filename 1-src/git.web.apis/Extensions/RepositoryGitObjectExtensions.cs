using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryGitObjectExtensions
    {
        public static RepositoryGitObjectResponse ToRepositoryGitObjectResponse(this GitObject @this)
        {
            return RepositoryGitObjectResponse.From(@this);
        }

        public static List<RepositoryGitObjectResponse> ToRepositoryGitObjectResponses(this IEnumerable<GitObject> @this)
        {
            return RepositoryGitObjectResponse.From(@this);
        }
    }
}
