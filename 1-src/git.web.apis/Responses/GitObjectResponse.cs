using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.LibGit2;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class GitObjectResponse
    {
        private GitObjectResponse()
        {
        }

        public string id { get; private set; }

        public string url { get; private set; }

        public GitObjectType type { get; private set; }

        public GitObjectResponse AddLinks(ILinkProvider linkProvider)
        {
            switch (type)
            {
                case GitObjectType.NONE:
                    break;
                case GitObjectType.COMMIT:
                    url = linkProvider.GetCommitById(id).herf;
                    break;
                case GitObjectType.TREE:
                    url = linkProvider.GetTreeById(id).herf;
                    break;
                case GitObjectType.BLOB:
                    url = linkProvider.GetBlobById(id).herf;
                    break;
                case GitObjectType.TAG:
                    break;
            }
            return this;
        }

        public static GitObjectResponse From(GitObject gitObject)
        {
            return new GitObjectResponse
            {
                id = gitObject.Sha,
                type = GitObjectTypes.GetGitObjectType(gitObject)
            };
        }

        public static List<GitObjectResponse> From(IEnumerable<GitObject> gitObjects)
        {
            return gitObjects.Select(From).ToList();
        }
    }
}
