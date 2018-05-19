using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public abstract class LinksResponse<TResponse>
    {
        public List<LinkResponse> _links { get; } = new List<LinkResponse>();

        protected void AddLink(LinkResponse linkResponse)
        {
            _links.Add(linkResponse);
        }

        protected void AddSelf(string herf)
        {
            AddLink(LinkResponse.From("self", herf));
        }

        public abstract TResponse AddLinks(IUrlHelper urlHelper) ;
    }
}
