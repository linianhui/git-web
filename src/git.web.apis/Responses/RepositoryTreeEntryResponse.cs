using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryTreeEntryResponse
    {
        private RepositoryTreeEntryResponse()
        {
        }

        public string path { get; private set; }

        public string name { get; private set; }

        public Mode mode { get; private set; }

        public RepositoryGitObjectResponse target { get; private set; }

        public RepositoryTreeEntryResponse AddLinks(ILinkProvider linkProvider)
        {
            target.AddLinks(linkProvider);
            return this;
        }

        public static RepositoryTreeEntryResponse From(TreeEntry treeEntry)
        {
            return new RepositoryTreeEntryResponse
            {
                path = treeEntry.Path,
                target = treeEntry.Target.ToRepositoryGitObjectResponse(),
                name = treeEntry.Name,
                mode = treeEntry.Mode
            };
        }

        public static List<RepositoryTreeEntryResponse> From(IEnumerable<TreeEntry> trees)
        {
            return trees.Select(From).ToList();
        }
    }
}
