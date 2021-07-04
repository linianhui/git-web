using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class RepositoryTagExtensions
    {
        public static RepositoryTagResponse ToRepositoryTagResponse(this Tag @this)
        {
            return RepositoryTagResponse.From(@this);
        }

        public static RepositoryTagAnnotationResponse ToRepositoryTagAnnotationResponse(this TagAnnotation @this)
        {
            return RepositoryTagAnnotationResponse.From(@this);
        }

        public static List<RepositoryTagResponse> ToRepositoryTagResponses(this IEnumerable<Tag> @this)
        {
            return RepositoryTagResponse.From(@this);
        }

        public static RepositoryTagListResponse ToRepositoryTagListResponse(this IEnumerable<Tag> @this)
        {
            return RepositoryTagListResponse.From(@this);
        }
    }
}
