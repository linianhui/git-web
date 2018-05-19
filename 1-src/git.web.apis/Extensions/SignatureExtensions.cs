using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class SignatureExtensions
    {
        public static UserResponse ToResponse(this Signature @this)
        {
            return UserResponse.From(@this);
        }
    }
}
