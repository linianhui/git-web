using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class SignatureExtensions
    {
        public static SignatureResponse ToSignatureResponse(this Signature @this)
        {
            return SignatureResponse.From(@this);
        }
    }
}
