using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class TagsResponse : LinkResponse<TagsResponse>
    {
        private TagsResponse()
        {
        }

        public List<TagResponse> tags { get; private set; }

        public override TagsResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTags());
            tags.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static TagsResponse From(IEnumerable<Tag> tags)
        {
            return new TagsResponse
            {
                tags = tags.ToTagResponses()
            };
        }
    }
}
