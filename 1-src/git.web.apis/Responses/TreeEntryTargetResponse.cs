using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TreeEntryTargetResponse
    {
        private TreeEntryTargetResponse()
        {
        }

        public string id { get; private set; }

        public string url { get; private set; }

        public TreeEntryTargetType type { get; private set; }

        public void AddLinks(ILinkProvider linkProvider)
        {
            switch (type)
            {
                case TreeEntryTargetType.Blob:
                    url = linkProvider.GetBlobById(id).herf;
                    break;

                case TreeEntryTargetType.Tree:
                    url = linkProvider.GetTreeById(id).herf;
                    break;

                case TreeEntryTargetType.GitLink:
                    break;
            }
        }

        public static TreeEntryTargetResponse From(TreeEntry treeEntry)
        {
            return new TreeEntryTargetResponse
            {
                id = treeEntry.Target.Sha,
                type = treeEntry.TargetType
            };
        }
    }
}
