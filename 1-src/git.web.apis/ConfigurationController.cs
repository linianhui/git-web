using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("configuration")]
    public class ConfigurationController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ConfigurationController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.GetConfiguration)]
        public ConfigurationResponse GetConfiguration()
        {
            var linkProvider = this.GetLinkProvider();

            return _repositoryFactory
                .GetRepository()
                .Config
                .ToConfigurationResponse()
                .AddLinks(linkProvider);
        }
    }
}
