using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class CommitsResponse : Links<CommitsResponse>
    {
        private CommitsResponse() { }

        public List<CommitResponse> commits { get; private set; }

        public static CommitsResponse From(IEnumerable<Commit> commits)
        {
            return new CommitsResponse
            {
                commits = commits.ToCommitResponses()
            };
        }

        public override CommitsResponse AddLinks(IUrls urls)
        {
            AddSelf(urls.GetCommits());
            commits.ForEach(_ => _.AddLinks(urls));
            return this;
        }
    }
}
