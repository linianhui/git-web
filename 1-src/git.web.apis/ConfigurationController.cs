using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("configuration")]
    public class ConfigurationController : Controller
    {
        private readonly IRepository _repository;

        public ConfigurationController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Rels.GetConfiguration)]
        public ConfigurationResponse GetConfiguration()
        {
            var linkProvider = new LinkProvider(Url);

            return _repository.Config
                .ToConfigurationResponse()
                .AddLinks(linkProvider);
        }
    }
}
