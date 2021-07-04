using Git.Web.Apis.Links;

namespace Git.Web.Apis.Responses
{
    public class RepositoryResponse : LinkResponse<RepositoryResponse>
    {
        public override RepositoryResponse WithLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetHome());
            AddLink(linkProvider.GetSwagger(".swagger"));
            AddLink(linkProvider.GetRedoc(".redoc"));
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
