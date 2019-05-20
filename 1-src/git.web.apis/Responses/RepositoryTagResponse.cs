using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryTagResponse : LinkResponse<RepositoryTagResponse>
    {
        private RepositoryTagResponse()
        {
        }

        public string canonical_name { get; private set; }

        public string friendly_name { get; private set; }

        public RepositoryTagAnnotationResponse annotation { get; private set; }

        public bool is_annotated { get; private set; }

        public object reference { get; set; }

        public object target { get; set; }

        public object peeled_target { get; set; }

        public override RepositoryTagResponse WithLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetTagByName(friendly_name));
            return this;
        }

        public static RepositoryTagResponse From(Tag tag)
        {
            return new RepositoryTagResponse
            {
                canonical_name = tag.CanonicalName,
                friendly_name = tag.FriendlyName,
                annotation = tag.Annotation.ToRepositoryTagAnnotationResponse(),
                is_annotated = tag.IsAnnotated,
                //peeled_target = tag.PeeledTarget,
                //reference = tag.Reference,
                //target = tag.Target
            };
        }

        public static List<RepositoryTagResponse> From(IEnumerable<Tag> tags)
        {
            return tags.Select(From).ToList();
        }
    }
}
