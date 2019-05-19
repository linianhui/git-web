using Git.Web.Apis.Routes;

namespace Git.Web.Apis.Responses
{
    public class RepositoryResponse : LinkResponse<RepositoryResponse>
    {
        public override RepositoryResponse AddLinks(ILinkProvider linkProvider)
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
