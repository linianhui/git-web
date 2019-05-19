using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RemoteListResponse : LinkResponse<RemoteListResponse>
    {
        private RemoteListResponse()
        {
        }

        public List<RemoteResponse> remotes { get; private set; }

        public override RemoteListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetRemotes());
            remotes.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RemoteListResponse From(IEnumerable<Remote> commits)
        {
            return new RemoteListResponse
            {
                remotes = commits.ToRemoteResponses()
            };
        }
    }
}
