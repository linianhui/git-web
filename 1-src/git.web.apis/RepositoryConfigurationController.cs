using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/configuration")]
    public class RepositoryConfigurationController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryConfigurationController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_CONFIGURTION_GET)]
        public ConfigurationResponse GetConfiguration(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Config
                .ToConfigurationResponse()
                .AddLinks(linkProvider);
        }
    }
}
