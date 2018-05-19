using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class TreeEntryResponse
    {
        private TreeEntryResponse() { }

        public string path { get; set; }

        public string name { get; set; }

        public Mode mode { get; set; }

        public IdResponse target { get; set; }

        public TreeEntryTargetType target_type { get; set; }

        public static TreeEntryResponse From(TreeEntry treeEntry)
        {
            return new TreeEntryResponse
            {
                path = treeEntry.Path,
                target_type = treeEntry.TargetType,
                target = treeEntry.Target.ToIdResponse(),
                name = treeEntry.Name,
                mode = treeEntry.Mode
            };
        }

        public static List<TreeEntryResponse> From(IEnumerable<TreeEntry> trees)
        {
            return trees.Select(From).ToList();
        }

        public void AddLinks(IUrlHelper url)

        {
            switch (target_type)
            {
                case TreeEntryTargetType.Blob:
                    break;
                case TreeEntryTargetType.Tree:
                    target.url = Trees.Links.Get(url, target.id);
                    break;
                case TreeEntryTargetType.GitLink:
                    break;
            }
        }
    }
}
