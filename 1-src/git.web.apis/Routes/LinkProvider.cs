using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Routes
{
    public class LinkProvider : ILinkProvider
    {
        private readonly IUrlHelper _urlHelper;
        private readonly string _repositoryName;

        public LinkProvider(IUrlHelper urlHelper, string repositoryName)
        {
            _urlHelper = urlHelper;
            _repositoryName = repositoryName;
        }

        public Link GetHome()
        {
            return GetLink(Rels.GetHome);
        }

        public Link GetDocs(string docsPath)
        {
            return Link.From(Rels.GetDocs, GetHome().herf + docsPath);
        }

        public Link GetRepositoryHome()
        {
            return GetRepositoryHome(_repositoryName);
        }

        public Link GetRepositoryHome(string repositoryName)
        {
            return GetLink(Rels.GetRepositoryHome, new { repositoryName });
        }

        public Link GetConfiguration()
        {
            return GetLink(Rels.GetConfiguration, new { repositoryName = _repositoryName });
        }

        public Link GetTags()
        {
            return GetLink(Rels.GetTags, new { repositoryName = _repositoryName });
        }

        public Link GetTagByName(string tagName)
        {
            return GetLink(Rels.GetTagByName, new { repositoryName = _repositoryName, tagName });
        }

        public Link GetHead()
        {
            return GetLink(Rels.GetHead, new { repositoryName = _repositoryName });
        }

        public Link GetRemotes()
        {
            return GetLink(Rels.GetRemotes, new { repositoryName = _repositoryName });
        }

        public Link GetRemoteByName(string remoteName)
        {
            return GetLink(Rels.GetRemoteByName, new { repositoryName = _repositoryName, remoteName });
        }

        public Link GetBranches()
        {
            return GetLink(Rels.GetBranches, new { repositoryName = _repositoryName });
        }

        public Link GetBranchByName(string branchName)
        {
            return GetLink(Rels.GetBranchByName, new { repositoryName = _repositoryName, branchName });
        }

        public Link GetCommitsByBranchName(string branchName)
        {
            return GetLink(Rels.GetCommitsByBranchName, new { repositoryName = _repositoryName, branchName });
        }

        public Link GetCommits()
        {
            return GetLink(Rels.GetCommits, new { repositoryName = _repositoryName });
        }

        public Link GetCommitById(string commitId)
        {
            return GetLink(Rels.GetCommitById, new { repositoryName = _repositoryName, commitId });
        }

        public Link GetTreeById(string treeId)
        {
            return GetLink(Rels.GetTreeById, new { repositoryName = _repositoryName, treeId });
        }

        public Link GetBlobById(string blobId)
        {
            return GetLink(Rels.GetBlobById, new { repositoryName = _repositoryName, blobId });
        }

        private Link GetLink(string rel, object values = null)
        {
            return Link.From(rel, _urlHelper.Link(rel, values));
        }
    }
}
