using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RemotesResponse : LinkResponse<RemotesResponse>
    {
        private RemotesResponse()
        {
        }

        public List<RemoteResponse> remotes { get; private set; }

        public override RemotesResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetRemotes());
            remotes.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RemotesResponse From(IEnumerable<Remote> commits)
        {
            return new RemotesResponse
            {
                remotes = commits.ToRemoteResponses()
            };
        }
    }
}
