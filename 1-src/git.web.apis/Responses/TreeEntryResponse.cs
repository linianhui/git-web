using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TreeEntryResponse
    {
        private TreeEntryResponse() { }

        public string path { get; private set; }

        public string name { get; private set; }

        public Mode mode { get; private set; }

        public TreeEntryTargetResponse target { get; private set; }

        public static TreeEntryResponse From(TreeEntry treeEntry)
        {
            return new TreeEntryResponse
            {
                path = treeEntry.Path,
                target = treeEntry.ToTreeEntryTargetResponse(),
                name = treeEntry.Name,
                mode = treeEntry.Mode
            };
        }

        public static List<TreeEntryResponse> From(IEnumerable<TreeEntry> trees)
        {
            return trees.Select(From).ToList();
        }

        public void AddLinks(IUrls urls)
        {
            target.AddLinks(urls);
        }
    }
}
