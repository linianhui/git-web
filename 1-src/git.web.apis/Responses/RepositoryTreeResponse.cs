using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryTreeResponse : LinkResponse<RepositoryTreeResponse>
    {
        private RepositoryTreeResponse()
        {
        }

        public string id { get; private set; }

        public int count { get; private set; }

        public List<RepositoryTreeEntryResponse> entries { get; private set; }

        public override RepositoryTreeResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTreeById(id));
            entries.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RepositoryTreeResponse From(Tree tree)
        {
            return new RepositoryTreeResponse
            {
                id = tree.Sha,
                count = tree.Count,
                entries = tree.ToRepositoryTreeEntryResponses()
            };
        }

        public static List<RepositoryTreeResponse> From(IEnumerable<Tree> trees)
        {
            return trees.Select(From).ToList();
        }
    }
}
