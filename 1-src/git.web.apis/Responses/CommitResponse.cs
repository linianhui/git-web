using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public class CommitResponse : LinksResponse<CommitResponse>
    {
        private CommitResponse() { }

        public string id { get; private set; }

        public UserResponse author { get; private set; }

        public string message { get; private set; }

        public UserResponse committer { get; private set; }

        public string encoding { get; private set; }

        public List<IdResponse> parents { get; private set; }

        public IdResponse tree { get; private set; }

        public static CommitResponse From(Commit commit)
        {
            return new CommitResponse
            {
                id = commit.Sha,
                encoding = commit.Encoding,
                author = commit.Author.ToResponse(),
                committer = commit.Committer.ToResponse(),
                message = commit.Message,
                parents = commit.Parents.ToIdResponses(),
                tree = commit.Tree.ToIdResponse()
            };
        }

        public static List<CommitResponse> From(IEnumerable<Commit> commits)
        {
            return commits.Select(From).ToList();
        }

        public override CommitResponse AddLinks(IUrlHelper url)
        {
            AddSelf(Routes.Commits.Links.Get(url, id));
            parents.ForEach(_ => _.url = Routes.Commits.Links.Get(url, _.id));
            return this;
        }
    }
}
