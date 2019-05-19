using System.Collections.Concurrent;
using System.Collections.Generic;
using Git.Web.Apis;
using LibGit2Sharp;
using System.Linq;

namespace Git.Web
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private static readonly IDictionary<string, IRepository> _repositorys = new ConcurrentDictionary<string, IRepository>();

        static RepositoryFactory()
        {
            _repositorys.Add("git.web", new Repository(@"d:\.code\.lnh\git.web"));
        }

        public IRepository GetRepository(string repositoryName)
        {
            return _repositorys[repositoryName];
        }

        public ISet<string> GetRepositoryNames()
        {
            return new SortedSet<string>(_repositorys.Keys);
        }
    }
}
