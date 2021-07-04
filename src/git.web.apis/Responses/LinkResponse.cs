using System.Collections.Generic;
using Git.Web.Apis.Links;

namespace Git.Web.Apis.Responses
{
    public abstract class LinkResponse<TResponse>
    {
        public IList<Link> _links { get; } = new List<Link>();

        public void AddSelf(string herf)
        {
            _links.Add(Link.Self(herf));
        }

        public void AddSelf(Link link)
        {
            _links.Add(Link.Self(link.herf));
        }

        public void AddLink(Link link)
        {
            _links.Add(link);
        }

        public abstract TResponse WithLinks(ILinkProvider linkProvider);
    }
}
