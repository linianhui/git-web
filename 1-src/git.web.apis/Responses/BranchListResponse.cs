using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class BranchListResponse : LinkResponse<BranchListResponse>
    {
        private BranchListResponse()
        {
        }

        public List<BranchResponse> branches { get; private set; }

        public override BranchListResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetBranches());
            branches.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static BranchListResponse From(IEnumerable<Branch> branches)
        {
            return new BranchListResponse
            {
                branches = branches.ToBranchResponses()
            };
        }
    }
}
