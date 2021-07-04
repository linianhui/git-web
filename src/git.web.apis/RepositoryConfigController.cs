using Git.Web.Apis.Extensions;
using Git.Web.Apis.Links;
using Git.Web.Apis.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("v1/repository/{repository_name}/config")]
    public class RepositoryConfigController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public RepositoryConfigController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet(Name = Rels.REPOSITORY_CONFIG_GET)]
        public RepositoryConfigResponse GetConfig(string repository_name)
        {
            var linkProvider = this.GetLinkProvider(repository_name);

            return _repositoryFactory
                .GetRepository(repository_name)
                .Config
                .ToRepositoryConfigResponse()
                .WithLinks(linkProvider);
        }
    }
}
