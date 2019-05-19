using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RepositoryTagListResponse : LinkResponse<RepositoryTagListResponse>
    {
        private RepositoryTagListResponse()
        {
        }

        public List<RepositoryTagResponse> tags { get; private set; }

        public override RepositoryTagListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTags());
            tags.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RepositoryTagListResponse From(IEnumerable<Tag> tags)
        {
            return new RepositoryTagListResponse
            {
                tags = tags.ToRepositoryTagResponses()
            };
        }
    }
}
