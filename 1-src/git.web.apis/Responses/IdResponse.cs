using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class IdResponse
    {
        private IdResponse()
        {
        }

        public string id { get; private set; }

        public string url { get; set; }

        public static IdResponse From(GitObject commit)
        {
            return new IdResponse
            {
                id = commit.Sha
            };
        }

        public static List<IdResponse> From(IEnumerable<GitObject> commits)
        {
            return commits.Select(From).ToList();
        }
    }
}
