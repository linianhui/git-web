using System.Collections.Generic;
using LibGit2Sharp;

namespace Git.Web.Apis
{
    public interface IRepositoryFactory
    {
        ISet<string> GetRepositoryNames();

        IRepository GetRepository(string repositoryName);
    }
}
