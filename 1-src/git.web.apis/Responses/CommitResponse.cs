using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class CommitResponse : LinkResponse<CommitResponse>
    {
        private CommitResponse()
        {
        }

        public string id { get; private set; }

        public SignatureResponse author { get; private set; }

        public string message { get; private set; }

        public SignatureResponse committer { get; private set; }

        public string encoding { get; private set; }

        public List<IdResponse> parents { get; private set; }

        public IdResponse tree { get; private set; }

        public override CommitResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetCommitById(id));
            parents.ForEach(_ => _.url = linkProvider.GetCommitById(_.id).herf);
            tree.url = linkProvider.GetTreeById(tree.id).herf;
            return this;
        }

        public static CommitResponse From(Commit commit)
        {
            return new CommitResponse
            {
                id = commit.Sha,
                encoding = commit.Encoding,
                author = commit.Author.ToSignatureResponse(),
                committer = commit.Committer.ToSignatureResponse(),
                message = commit.Message,
                parents = commit.Parents.ToIdResponses(),
                tree = commit.Tree.ToIdResponse()
            };
        }

        public static List<CommitResponse> From(IEnumerable<Commit> commits)
        {
            return commits.Select(From).ToList();
        }
    }
}
