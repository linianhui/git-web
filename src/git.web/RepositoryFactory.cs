using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Git.Web.Apis;
using LibGit2Sharp;
using Microsoft.Extensions.Logging;

namespace Git.Web
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ILogger<RepositoryFactory> _logger;

        private static readonly IDictionary<string, IRepository> _repositorys = new ConcurrentDictionary<string, IRepository>();

        private static readonly string _repositorysPath = Path.Combine(AppContext.BaseDirectory, "repos");

        public RepositoryFactory(ILogger<RepositoryFactory> logger)
        {
            _logger = logger;
        }

        public void Reload()
        {
            if (Directory.Exists(_repositorysPath) == false)
            {
                Directory.CreateDirectory(_repositorysPath);
            }

            foreach (var repositoryPath in Directory.GetDirectories(_repositorysPath))
            {
                AddRepository(repositoryPath);
            }
        }

        public ISet<string> GetRepositoryNames()
        {
            return new SortedSet<string>(_repositorys.Keys);
        }

        public IRepository GetRepository(string repositoryName)
        {
            return _repositorys[repositoryName];
        }

        public void CloneRepository(string repositoryName, string repositoryUrl)
        {
            _logger.LogInformation("CloneRepository({0},{1})", repositoryName, repositoryUrl);

            if (_repositorys.ContainsKey(repositoryName))
            {
                return;
            }
            var repositoryPath = Path.Combine(_repositorysPath, repositoryName);
            Repository.Clone(repositoryUrl, repositoryPath, new CloneOptions
            {
                IsBare = true
            });
            AddRepository(repositoryName, repositoryPath);
        }


        private void AddRepository(string repositoryPath)
        {
            var repositoryName = new DirectoryInfo(repositoryPath).Name;
            AddRepository(repositoryName, repositoryPath);
        }

        private void AddRepository(string repositoryName, string repositoryPath)
        {
            _logger.LogInformation("AddRepository({0},{1})", repositoryName, repositoryPath);
            _repositorys.Add(repositoryName, new Repository(repositoryPath));
        }
    }
}
