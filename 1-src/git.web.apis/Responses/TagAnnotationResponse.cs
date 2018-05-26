using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class TagAnnotationResponse
    {
        private TagAnnotationResponse()
        {
        }

        public string id { get; private set; }

        public string message { get; private set; }

        public string name { get; private set; }

        public SignatureResponse tagger { get; private set; }

        public GitObject target { get; private set; }

        public static TagAnnotationResponse From(TagAnnotation tagAnnotation)
        {
            if (tagAnnotation == null)
            {
                return null;
            }

            return new TagAnnotationResponse
            {
                id = tagAnnotation.Sha,
                message = tagAnnotation.Message,
                name = tagAnnotation.Name,
                tagger = tagAnnotation.Tagger.ToSignatureResponse(),
               //target = tagAnnotation.Target
            };
        }
    }
}
