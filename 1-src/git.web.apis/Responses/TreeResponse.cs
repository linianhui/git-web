using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TreeResponse : Links<TreeResponse>
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

        public override TreeResponse AddLinks(IUrls urls)
        {
            AddSelf(urls.GetTree(id));
            entries.ForEach(_ => _.AddLinks(urls));
            return this;
        }
    }
}
