using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RepositoryRemoteListResponse : LinkResponse<RepositoryRemoteListResponse>
    {
        private RepositoryRemoteListResponse()
        {
        }

        public List<RepositoryRemoteResponse> remotes { get; private set; }

        public override RepositoryRemoteListResponse WithLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetRemotes());
            remotes.ForEach(_ => _.WithLinks(linkProvider));
            return this;
        }

        public static RepositoryRemoteListResponse From(IEnumerable<Remote> commits)
        {
            return new RepositoryRemoteListResponse
            {
                remotes = commits.ToRepositoryRemoteResponses()
            };
        }
    }
}
