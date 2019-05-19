using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryTagAnnotationResponse
    {
        private RepositoryTagAnnotationResponse()
        {
        }

        public string id { get; private set; }

        public string message { get; private set; }

        public string name { get; private set; }

        public RepositorySignatureResponse tagger { get; private set; }

        public GitObject target { get; private set; }

        public static RepositoryTagAnnotationResponse From(TagAnnotation tagAnnotation)
        {
            if (tagAnnotation == null)
            {
                return null;
            }

            return new RepositoryTagAnnotationResponse
            {
                id = tagAnnotation.Sha,
                message = tagAnnotation.Message,
                name = tagAnnotation.Name,
                tagger = tagAnnotation.Tagger.ToRepositorySignatureResponse(),
                //target = tagAnnotation.Target
            };
        }
    }
}
