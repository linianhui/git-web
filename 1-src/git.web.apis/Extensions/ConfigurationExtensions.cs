using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ConfigurationResponse ToConfigurationResponse(this Configuration @this)
        {
            return ConfigurationResponse.From(@this);
        }
    }
}
