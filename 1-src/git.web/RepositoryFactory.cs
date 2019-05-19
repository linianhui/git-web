using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis;
using LibGit2Sharp;

namespace Git.Web
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private static readonly IDictionary<string, IRepository> _repositorys = new ConcurrentDictionary<string, IRepository>();

        static RepositoryFactory()
        {
            _repositorys.Add("local", new Repository(@"d:\.code\.lnh\git.web"));
        }

        public IRepository GetRepository()
        {
            return _repositorys.First().Value;
        }
    }
}
