using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryBranchExtensions
    {
        public static RepositoryBranchResponse ToRepositoryBranchResponse(this Branch @this)
        {
            return RepositoryBranchResponse.From(@this);
        }

        public static List<RepositoryBranchResponse> ToRepositoryBranchResponses(this IEnumerable<Branch> @this)
        {
            return RepositoryBranchResponse.From(@this);
        }

        public static RepositoryBranchListResponse ToRepositoryBranchListResponse(this IEnumerable<Branch> @this)
        {
            return RepositoryBranchListResponse.From(@this);
        }
    }
}
