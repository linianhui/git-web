using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RemoteResponse : LinkResponse<RemoteResponse>
    {
        private RemoteResponse()
        {
        }

        public string name { get; private set; }

        public string url { get; private set; }

        public string push_url { get; private set; }

        public TagFetchMode tag_fetch_mode { get; set; }

        public bool automatically_prune_on_fetch { get; private set; }

        public IList<RefSpecResponse> fetch_ref_specs { get; set; }

        public IList<RefSpecResponse> push_ref_specs { get; set; }

        public IList<RefSpecResponse> ref_apecs { get; set; }

        public override RemoteResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetRemoteByName(name));
            return this;
        }

        public static RemoteResponse From(Remote remote)
        {
            return new RemoteResponse
            {
                name = remote.Name,
                automatically_prune_on_fetch = remote.AutomaticallyPruneOnFetch,
                ref_apecs = remote.RefSpecs.ToRefSpecResponses(),
                fetch_ref_specs = remote.FetchRefSpecs.ToRefSpecResponses(),
                push_ref_specs = remote.PushRefSpecs.ToRefSpecResponses(),
                push_url = remote.PushUrl,
                tag_fetch_mode = remote.TagFetchMode,
                url = remote.Url
            };
        }

        public static List<RemoteResponse> From(IEnumerable<Remote> remotes)
        {
            return remotes.Select(From).ToList();
        }
    }
}
