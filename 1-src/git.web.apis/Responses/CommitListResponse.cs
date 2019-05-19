using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class CommitListResponse : LinkResponse<CommitListResponse>
    {
        private CommitListResponse()
        {
        }

        public List<CommitResponse> commits { get; private set; }

        public override CommitListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetCommits());
            commits.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static CommitListResponse From(IEnumerable<Commit> commits)
        {
            return new CommitListResponse
            {
                commits = commits.ToCommitResponses()
            };
        }
    }
}
