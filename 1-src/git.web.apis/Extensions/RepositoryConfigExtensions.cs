using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryConfigExtensions
    {
        public static RepositoryConfigResponse ToRepositoryConfigResponse(this Configuration @this)
        {
            return RepositoryConfigResponse.From(@this);
        }
    }
}
