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
            return GetLink(Rels.HOME_GET);
        }

        public Link GetDocs(string docsPath)
        {
            return Link.From(Rels.DOCS_GET, GetHome().herf + docsPath);
        }

        public Link GetRepository()
        {
            return GetRepository(_repositoryName);
        }

        public Link GetRepository(string repositoryName)
        {
            return GetLink(Rels.REPOSITORY_GET, new { repositoryName });
        }

        public Link CloneRepository(string repositoryName, string repositoryUrl)
        {
            return GetLink(Rels.REPOSITORY_CLONE, new { repositoryName, repositoryUrl });
        }

        public Link GetConfiguration()
        {
            return GetLink(Rels.REPOSITORY_CONFIGURTION_GET, new { repositoryName = _repositoryName });
        }

        public Link GetTags()
        {
            return GetLink(Rels.REPOSITORY_TAG_GET_LIST, new { repositoryName = _repositoryName });
        }

        public Link GetTagByName(string tagName)
        {
            return GetLink(Rels.REPOSITORY_TAG_GET_BY_NAME, new { repositoryName = _repositoryName, tagName });
        }

        public Link GetHead()
        {
            return GetLink(Rels.REPOSITORY_HEAD_GET, new { repositoryName = _repositoryName });
        }

        public Link GetRemotes()
        {
            return GetLink(Rels.REPOSITORY_REMOTE_GET_LIST, new { repositoryName = _repositoryName });
        }

        public Link GetRemoteByName(string remoteName)
        {
            return GetLink(Rels.REPOSITORY_REMOTE_GET_BY_NAME, new { repositoryName = _repositoryName, remoteName });
        }

        public Link GetBranches()
        {
            return GetLink(Rels.REPOSITORY_BRANCH_GET_LIST, new { repositoryName = _repositoryName });
        }

        public Link GetBranchByName(string branchName)
        {
            return GetLink(Rels.REPOSITORY_BRANCH_GET_BY_NAME, new { repositoryName = _repositoryName, branchName });
        }

        public Link GetCommitsByBranchName(string branchName)
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_LIST_BY_BRANCH_NAME, new { repositoryName = _repositoryName, branchName });
        }

        public Link GetCommits()
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_LIST, new { repositoryName = _repositoryName });
        }

        public Link GetCommitById(string commitId)
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_BY_ID, new { repositoryName = _repositoryName, commitId });
        }

        public Link GetTreeById(string treeId)
        {
            return GetLink(Rels.REPOSITORY_TREE_GET_BY_ID, new { repositoryName = _repositoryName, treeId });
        }

        public Link GetBlobById(string blobId)
        {
            return GetLink(Rels.REPOSITORY_BLOB_GET_BY_ID, new { repositoryName = _repositoryName, blobId });
        }

        private Link GetLink(string rel, object values = null)
        {
            return Link.From(rel, _urlHelper.Link(rel, values));
        }
    }
}
