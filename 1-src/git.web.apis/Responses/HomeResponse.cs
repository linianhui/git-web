using Git.Web.Apis.Routes;

namespace Git.Web.Apis.Responses
{
    public class HomeResponse : LinkResponse<HomeResponse>
    {
        public override HomeResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetHome());
            AddLink(linkProvider.GetDocs(".docs"));
            AddLink(linkProvider.GetConfiguration());
            AddLink(linkProvider.GetBranches());
            AddLink(linkProvider.GetTags());
            AddLink(linkProvider.GetCommits());
            AddLink(linkProvider.GetHead());
            AddLink(linkProvider.GetRemotes());
            return this;
        }
    }
}