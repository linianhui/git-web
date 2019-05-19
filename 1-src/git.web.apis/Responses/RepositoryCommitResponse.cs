using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryCommitResponse : LinkResponse<RepositoryCommitResponse>
    {
        private RepositoryCommitResponse()
        {
        }

        public string id { get; private set; }

        public RepositorySignatureResponse author { get; private set; }

        public string message { get; private set; }

        public RepositorySignatureResponse committer { get; private set; }

        public string encoding { get; private set; }

        public List<RepositoryGitObjectResponse> parents { get; private set; }

        public RepositoryGitObjectResponse tree { get; private set; }

        public override RepositoryCommitResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetCommitById(id));
            parents.ForEach(_ => _.AddLinks(linkProvider));
            tree.AddLinks(linkProvider);
            return this;
        }

        public static RepositoryCommitResponse From(Commit commit)
        {
            return new RepositoryCommitResponse
            {
                id = commit.Sha,
                encoding = commit.Encoding,
                author = commit.Author.ToRepositorySignatureResponse(),
                committer = commit.Committer.ToRepositorySignatureResponse(),
                message = commit.Message,
                parents = commit.Parents.ToRepositoryGitObjectResponses(),
                tree = commit.Tree.ToRepositoryGitObjectResponse()
            };
        }

        public static List<RepositoryCommitResponse> From(IEnumerable<Commit> commits)
        {
            return commits.Select(From).ToList();
        }
    }
}
