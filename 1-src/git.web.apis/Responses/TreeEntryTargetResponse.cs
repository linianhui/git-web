using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class TreeEntryTargetResponse
    {
        private TreeEntryTargetResponse() { }

        public string id { get; private set; }

        public string url { get; private set; }

        public TreeEntryTargetType type { get; private set; }

        public static TreeEntryTargetResponse From(TreeEntry treeEntry)
        {
            return new TreeEntryTargetResponse
            {
                id = treeEntry.Target.Sha,
                type = treeEntry.TargetType
            };
        }

        public void AddLinks(IUrlHelper url)
        {
            switch (type)
            {
                case TreeEntryTargetType.Blob:
                    this.url = Routes.Blobs.Links.Get(url, id);
                    break;
                case TreeEntryTargetType.Tree:
                    this.url = Routes.Trees.Links.Get(url, id);
                    break;
                case TreeEntryTargetType.GitLink:
                    break;
            }
        }
    }
}
