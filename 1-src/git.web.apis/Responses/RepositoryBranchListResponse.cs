using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RepositoryBranchListResponse : LinkResponse<RepositoryBranchListResponse>
    {
        private RepositoryBranchListResponse()
        {
        }

        public List<RepositoryBranchResponse> branches { get; private set; }

        public override RepositoryBranchListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetBranches());
            branches.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static RepositoryBranchListResponse From(IEnumerable<Branch> branches)
        {
            return new RepositoryBranchListResponse
            {
                branches = branches.ToRepositoryBranchResponses()
            };
        }
    }
}
