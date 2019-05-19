using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RepositoryCommitListResponse : LinkResponse<RepositoryCommitListResponse>
    {
        private RepositoryCommitListResponse()
        {
        }

        public List<RepositoryCommitResponse> commits { get; private set; }

        public override RepositoryCommitListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetCommits());
            commits.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RepositoryCommitListResponse From(IEnumerable<Commit> commits)
        {
            return new RepositoryCommitListResponse
            {
                commits = commits.ToRepositoryCommitResponses()
            };
        }
    }
}
