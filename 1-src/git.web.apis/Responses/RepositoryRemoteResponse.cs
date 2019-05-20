using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryRemoteResponse : LinkResponse<RepositoryRemoteResponse>
    {
        private RepositoryRemoteResponse()
        {
        }

        public string name { get; private set; }

        public string url { get; private set; }

        public string push_url { get; private set; }

        public TagFetchMode tag_fetch_mode { get; set; }

        public bool automatically_prune_on_fetch { get; private set; }

        public IList<RepositoryRefSpecResponse> fetch_ref_specs { get; set; }

        public IList<RepositoryRefSpecResponse> push_ref_specs { get; set; }

        public IList<RepositoryRefSpecResponse> ref_apecs { get; set; }

        public override RepositoryRemoteResponse WithLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetRemoteByName(name));
            return this;
        }

        public static RepositoryRemoteResponse From(Remote remote)
        {
            return new RepositoryRemoteResponse
            {
                name = remote.Name,
                automatically_prune_on_fetch = remote.AutomaticallyPruneOnFetch,
                ref_apecs = remote.RefSpecs.ToRepositoryRefSpecResponses(),
                fetch_ref_specs = remote.FetchRefSpecs.ToRepositoryRefSpecResponses(),
                push_ref_specs = remote.PushRefSpecs.ToRepositoryRefSpecResponses(),
                push_url = remote.PushUrl,
                tag_fetch_mode = remote.TagFetchMode,
                url = remote.Url
            };
        }

        public static List<RepositoryRemoteResponse> From(IEnumerable<Remote> remotes)
        {
            return remotes.Select(From).ToList();
        }
    }
}
