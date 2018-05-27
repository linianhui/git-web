using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Routes
{
    public class LinkProvider : ILinkProvider
    {
        private readonly IUrlHelper _urlHelper;

        public LinkProvider(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Link GetHome()
        {
            return GetLink(Rels.GetHome);
        }

        public Link GetDocs(string docsPath)
        {
            return Link.From(Rels.GetDocs, GetHome().herf + docsPath);
        }

        public Link GetConfiguration()
        {
            return GetLink(Rels.GetConfiguration);
        }

        public Link GetTags()
        {
            return GetLink(Rels.GetTags);
        }

        public Link GetTagByName(string tagName)
        {
            return GetLink(Rels.GetTagByName, new { tagName });
        }

        public Link GetHead()
        {
            return GetLink(Rels.GetHead);
        }

        public Link GetRemotes()
        {
            return GetLink(Rels.GetRemotes);
        }

        public Link GetRemoteByName(string remoteName)
        {
            return GetLink(Rels.GetRemoteByName, new { remoteName });
        }

        public Link GetBranches()
        {
            return GetLink(Rels.GetBranches);
        }

        public Link GetBranchByName(string branchName)
        {
            return GetLink(Rels.GetBranchByName, new { branchName });
        }

        public Link GetCommitsByBranchName(string branchName)
        {
            return GetLink(Rels.GetCommitsByBranchName, new { branchName });
        }

        public Link GetCommits()
        {
            return GetLink(Rels.GetCommits);
        }

        public Link GetCommitById(string commitId)
        {
            return GetLink(Rels.GetCommitById, new { commitId });
        }

        public Link GetTreeById(string treeId)
        {
            return GetLink(Rels.GetTreeById, new { treeId });
        }

        public Link GetBlobById(string blobId)
        {
            return GetLink(Rels.GetBlobById, new { blobId });
        }

        private Link GetLink(string rel, object values = null)
        {
            return Link.From(rel, _urlHelper.Link(rel, values));
        }
    }
}
