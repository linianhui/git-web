using System.Collections.Generic;
using Git.Web.Apis.Responses;
using LibGit2Sharp;

namespace Git.Web.Apis.Extensions
{
    public static class TagExtensions
    {
        public static TagResponse ToTagResponse(this Tag @this)
        {
            return TagResponse.From(@this);
        }

        public static TagAnnotationResponse ToTagAnnotationResponse(this TagAnnotation @this)
        {
            return TagAnnotationResponse.From(@this);
        }

        public static List<TagResponse> ToTagResponses(this IEnumerable<Tag> @this)
        {
            return TagResponse.From(@this);
        }

        public static TagListResponse ToTagListResponse(this IEnumerable<Tag> @this)
        {
            return TagListResponse.From(@this);
        }
    }
}
