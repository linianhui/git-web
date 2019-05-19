using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class TagListResponse : LinkResponse<TagListResponse>
    {
        private TagListResponse()
        {
        }

        public List<TagResponse> tags { get; private set; }

        public override TagListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTags());
            tags.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static TagListResponse From(IEnumerable<Tag> tags)
        {
            return new TagListResponse
            {
                tags = tags.ToTagResponses()
            };
        }
    }
}
