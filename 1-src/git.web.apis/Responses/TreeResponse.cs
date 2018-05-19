using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class TreeResponse : LinksResponse<TreeResponse>
    {
        private TreeResponse() { }

        public string id { get; private set; }

        public int count { get; private set; }

        public List<TreeEntryResponse> entrys { get; private set; }

        public static TreeResponse From(Tree tree)
        {
            return new TreeResponse
            {
                id = tree.Sha,
                count = tree.Count,
                entrys = tree.ToTreeEntryResponses()
            };
        }

        public static List<TreeResponse> From(IEnumerable<Tree> trees)
        {
            return trees.Select(From).ToList();
        }

        public override TreeResponse AddLinks(IUrlHelper url)
        {
            AddSelf(Trees.Links.Get(url, id));
            entrys.ForEach(_ => _.AddLinks(url));
            return this;
        }
    }
}
