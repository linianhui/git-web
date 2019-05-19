using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Extensions
{
    public static class ControllerExtensions
    {
        public static ILinkProvider GetLinkProvider(this ControllerBase @this, string repositoryName)
        {
            return new LinkProvider(@this.Url, repositoryName);
        }
    }
}
