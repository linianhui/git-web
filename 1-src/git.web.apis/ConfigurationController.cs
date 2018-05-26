using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;

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
        [HttpGet(Name = Urls.Names.GetConfiguration)]
        public ConfigurationResponse GetConfiguration()
        {
            var urls = new Urls(Url);

            return _repository.Config
                .ToConfigurationResponse()
                .AddLinks(urls);
        }
    }
}
