using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class BranchResponse : LinkResponse<BranchResponse>
    {
        private BranchResponse()
        {
        }

        public string canonical_name { get; private set; }

        public string friendly_name { get; private set; }

        public string remote_name { get; private set; }

        public string upstream_branch_canonical_name { get; private set; }

        public bool is_current_repository_head { get; private set; }

        public bool is_remote { get; private set; }

        public bool is_tracking { get; private set; }

        public object tracking_details { get; set; }

        public object tracked_branch { get; set; }

        public IdResponse tip { get; set; }

        public object reference { get; set; }

        public override BranchResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetBranchByName(canonical_name));
            AddLink(linkProvider.GetCommitsByBranchName(canonical_name));
            tip.url = linkProvider.GetCommitById(tip.id).herf;
            return this;
        }

        public static BranchResponse From(Branch branch)
        {
            return new BranchResponse
            {
                canonical_name = branch.CanonicalName,
                friendly_name = branch.FriendlyName,
                is_current_repository_head = branch.IsCurrentRepositoryHead,
                is_remote = branch.IsRemote,
                is_tracking = branch.IsTracking,
                //reference = branch.Reference,
                remote_name = branch.RemoteName,
                tip = branch.Tip.ToIdResponse(),
                //tracked_branch = branch.TrackedBranch,
                //tracking_details = branch.TrackingDetails,
                upstream_branch_canonical_name = branch.UpstreamBranchCanonicalName
            };
        }

        public static List<BranchResponse> From(IEnumerable<Branch> branchs)
        {
            return branchs.Select(From).ToList();
        }
    }
}
