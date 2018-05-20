using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    public static partial class Routes
    {
        public static class Trees
        {
            public const string GET = "trees.get";

            public static class Links
            {
                public static string Get(IUrlHelper url, string treeId)
                {
                    return url.Link(GET, new {tree_id = treeId});
                }
            }
        }
    }
}
