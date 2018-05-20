using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    public static partial class Routes
    {
        public static class Commits
        {
            public const string GET_ALL = "commits.get.all";
            public const string GET = "commits.get";

            public static class Links
            {
                public static string GetAll(IUrlHelper url)
                {
                    return url.Link(GET_ALL, null);
                }

                public static string Get(IUrlHelper url, string commitId)
                {
                    return url.Link(GET, new {commit_id = commitId});
                }
            }
        }
    }
}
