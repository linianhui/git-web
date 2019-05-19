using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repositoryName}/config")]
    public class RepositoryConfigController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryConfigController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_CONFIG_GET)]
        public ConfigResponse GetConfig(string repositoryName)
        {
            var linkProvider = this.GetLinkProvider(repositoryName);

            return _repositoryFactory
                .GetRepository(repositoryName)
                .Config
                .ToConfigResponse()
                .AddLinks(linkProvider);
        }
    }
}
