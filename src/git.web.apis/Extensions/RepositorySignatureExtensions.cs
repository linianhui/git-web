using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositorySignatureExtensions
    {
        public static RepositorySignatureResponse ToRepositorySignatureResponse(this Signature @this)
        {
            return RepositorySignatureResponse.From(@this);
        }
    }
}
