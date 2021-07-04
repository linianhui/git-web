using System;
using LibGit2Sharp;

namespace Git.Web.Apis.LibGit2
{
    public static class RepositoryExtensions
    {
        public static Tag FindTag(this IRepository @this, string tagName)
        {
            if (@this == null || tagName == null)
            {
                return null;
            }

            tagName = Uri.UnescapeDataString(tagName);

            return @this.Tags[tagName];
        }

        public static Branch FindBranch(this IRepository @this, string branchName)
        {
            if (@this == null || branchName == null)
            {
                return null;
            }

            branchName = Uri.UnescapeDataString(branchName);

            return @this.Branches[branchName];
        }

        public static Remote FindRemote(this IRepository @this, string remoteName)
        {
            if (@this == null || remoteName == null)
            {
                return null;
            }

            remoteName = Uri.UnescapeDataString(remoteName);

            return @this.Network.Remotes[remoteName];
        }
    }
}
