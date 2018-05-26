using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TreeResponse : LinkResponse<TreeResponse>
    {
        private TreeResponse()
        {
        }

        public string id { get; private set; }

        public int count { get; private set; }

        public List<TreeEntryResponse> entries { get; private set; }

        public override TreeResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTreeById(id));
            entries.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

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
    }
}
