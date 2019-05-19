using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class ConfigExtensions
    {
        public static ConfigResponse ToConfigResponse(this Configuration @this)
        {
            return ConfigResponse.From(@this);
        }
    }
}
