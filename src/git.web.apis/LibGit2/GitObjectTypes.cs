using System;
using System.Collections.Generic;
using LibGit2Sharp;

namespace Git.Web.Apis.LibGit2
{
    public static class GitObjectTypes
    {
        private static readonly IDictionary<Type, GitObjectType> _types = new Dictionary<Type, GitObjectType>
        {
            [typeof(Commit)] = GitObjectType.COMMIT,
            [typeof(Tree)] = GitObjectType.TREE,
            [typeof(Blob)] = GitObjectType.BLOB,
            [typeof(TagAnnotation)] = GitObjectType.TAG
        };

        public static GitObjectType GetGitObjectType(GitObject gitObject)
        {
            var type = gitObject.GetType();
            if (_types.ContainsKey(type))
            {
                return _types[type];
            }

            return GitObjectType.NONE;
        }
    }
}
