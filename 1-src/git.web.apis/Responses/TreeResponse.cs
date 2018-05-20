using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class TreeResponse : LinksResponse<TreeResponse>
    {
        private TreeResponse() { }

        public string id { get; private set; }

        public int count { get; private set; }

        public List<TreeEntryResponse> entries { get; private set; }

        public static TreeResponse From(Tree tree)
        {
            return new TreeResponse
            {
                id = tree.Sha,
                count = tree.Count,
                entries = tree.ToTreeEntryResponses()
            };
        }

        public static List<TreeResponse> From(IEnumerable<Tree> trees)
        {
            return trees.Select(From).ToList();
        }

        public override TreeResponse AddLinks(IUrlHelper url)
        {
            AddSelf(Routes.Trees.Links.Get(url, id));
            entries.ForEach(_ => _.AddLinks(url));
            return this;
        }
    }
}
