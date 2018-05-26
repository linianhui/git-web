using System.Collections.Generic;

namespace Git.Web.Apis.Responses
{
    public abstract class Links<TResponse>
    {
        public List<Link> _links { get; } = new List<Link>();

        protected void AddLink(Link link)
        {
            _links.Add(link);
        }

        protected void AddSelf(string herf)
        {
            AddLink(Link.From("self", herf));
        }

        public abstract TResponse AddLinks(IUrls urls) ;
    }
}
