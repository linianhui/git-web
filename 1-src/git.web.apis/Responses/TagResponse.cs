using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TagResponse : LinkResponse<TagResponse>
    {
        private TagResponse()
        {
        }

        public string canonical_name { get; private set; }

        public string friendly_name { get; private set; }

        public TagAnnotationResponse annotation { get; private set; }

        public bool is_annotated { get; private set; }

        public object reference { get; set; }

        public object target { get; set; }

        public object peeled_target { get; set; }

        public override TagResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTagByName(friendly_name));
            return this;
        }

        public static TagResponse From(Tag tag)
        {
            return new TagResponse
            {
                canonical_name = tag.CanonicalName,
                friendly_name = tag.FriendlyName,
                annotation = tag.Annotation.ToTagAnnotationResponse(),
                is_annotated = tag.IsAnnotated,
                //peeled_target = tag.PeeledTarget,
                //reference = tag.Reference,
                //target = tag.Target
            };
        }

        public static List<TagResponse> From(IEnumerable<Tag> tags)
        {
            return tags.Select(From).ToList();
        }
    }
}
