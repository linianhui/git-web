using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TreeEntryResponse
    {
        private TreeEntryResponse()
        {
        }

        public string path { get; private set; }

        public string name { get; private set; }

        public Mode mode { get; private set; }

        public GitObjectResponse target { get; private set; }

        public TreeEntryResponse AddLinks(ILinkProvider linkProvider)
        {
            target.AddLinks(linkProvider);
            return this;
        }

        public static TreeEntryResponse From(TreeEntry treeEntry)
        {
            return new TreeEntryResponse
            {
                path = treeEntry.Path,
                target = treeEntry.Target.ToGitObjectResponse(),
                name = treeEntry.Name,
                mode = treeEntry.Mode
            };
        }

        public static List<TreeEntryResponse> From(IEnumerable<TreeEntry> trees)
        {
            return trees.Select(From).ToList();
        }
    }
}
