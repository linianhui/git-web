using System.Collections.Generic;
using LibGit2Sharp;

namespace Git.Web.Apis
{
    public interface IRepositoryFactory
    {
        void Reload();

        ISet<string> GetRepositoryNames();

        void CloneRepository(string repositoryName, string repositoryUrl);

        IRepository GetRepository(string repositoryName);
    }
}
