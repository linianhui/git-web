using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class BranchesResponse : LinkResponse<BranchesResponse>
    {
        private BranchesResponse()
        {
        }

        public List<BranchResponse> branches { get; private set; }

        public override BranchesResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetBranches());
            branches.ForEach(_ => _.AddLinks(linkProvider));
            return this;
        }

        public static BranchesResponse From(IEnumerable<Branch> branches)
        {
            return new BranchesResponse
            {
                branches = branches.ToBranchResponses()
            };
        }
    }
}
