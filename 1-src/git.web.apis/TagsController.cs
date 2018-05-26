using System;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Responses;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    [Route("tags")]
    public class TagsController : Controller
    {
        private readonly IRepository _repository;

        public TagsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = Rels.GetTags)]
        public TagsResponse GetTags()
        {
            var linkProvider = this.GetLinkProvider();

            return _repository.Tags
                .ToTagsResponse()
                .AddLinks(linkProvider);
        }

        [HttpGet("{tagName}", Name = Rels.GetTagByName)]
        public TagResponse GetTagByName(string tagName)
        {
            var linkProvider = this.GetLinkProvider();

            return FindTag(tagName)
                ?.ToTagResponse()
                .AddLinks(linkProvider);
        }

        private Tag FindTag(string tagName)
        {
            if (tagName == null)
            {
                return null;
            }

            tagName = Uri.UnescapeDataString(tagName);

            return _repository.Tags
                .FirstOrDefault(_ => _.FriendlyName == tagName || _.CanonicalName == tagName);
        }
    }
}
