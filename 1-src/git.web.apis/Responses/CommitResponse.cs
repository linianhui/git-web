using Git.Web.Apis.Extensions;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class CommitResponse : LinksResponse<CommitResponse>
    {
        private CommitResponse() { }

        public string sha { get; private set; }

        public UserResponse author { get; private set; }

        public string message { get; private set; }

        public UserResponse committer { get; private set; }

        public string encoding { get; private set; }

        public static CommitResponse From(Commit commit)
        {
            return new CommitResponse
            {
                sha = commit.Sha,
                encoding = commit.Encoding,
                author = commit.Author.ToResponse(),
                committer = commit.Committer.ToResponse(),
                message = commit.Message
            };
        }

        public override CommitResponse AddLinks(IUrlHelper urlHelper)
        {
            AddSelf(Routes.Commits.Links.Get(urlHelper, sha));
            return this;
        }
    }
}
