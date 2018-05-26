using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class CommitsResponse : LinkResponse<CommitsResponse>
    {
        private CommitsResponse()
        {
        }

        public List<CommitResponse> commits { get; private set; }

        public override CommitsResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetCommits());
            commits.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static CommitsResponse From(IEnumerable<Commit> commits)
        {
            return new CommitsResponse
            {
                commits = commits.ToCommitResponses()
            };
        }
    }
}
