using LibGit2Sharp;

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

        public void AddLinks(IUrls urls)
        {
            switch (type)
            {
                case TreeEntryTargetType.Blob:
                    url = urls.GetBlobById(id);
                    break;
                case TreeEntryTargetType.Tree:
                    url = urls.GetTreeById(id);
                    break;
                case TreeEntryTargetType.GitLink:
                    break;
            }
        }
    }
}
