using System.Collections.Generic;
using Git.Web.Apis.Extensions;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class BranchesResponse : Links<BranchesResponse>
    {
        private BranchesResponse() { }

        public List<BranchResponse> branches { get; private set; }

        public static BranchesResponse From(IEnumerable<Branch> branches)
        {
            return new BranchesResponse
            {
                branches = branches.ToBranchResponses()
            };
        }

        public override BranchesResponse AddLinks(IUrls urls)
        {
            AddSelf(urls.GetBranches());
            branches.ForEach(_ => _.AddLinks(urls));
            return this;
        }
    }
}
