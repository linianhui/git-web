using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Links
{
    public class LinkProvider : ILinkProvider
    {
        private readonly IUrlHelper _urlHelper;
        private readonly string repository_name;

        public LinkProvider(IUrlHelper urlHelper, string repository_name)
        {
            _urlHelper = urlHelper;
            this.repository_name = repository_name;
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
            return GetRepository(repository_name);
        }

        public Link GetRepository(string repository_name)
        {
            return GetLink(Rels.REPOSITORY_GET, new { repository_name });
        }

        public Link CloneRepository(string repository_name, string repository_url)
        {
            return GetLink(Rels.REPOSITORY_CLONE, new { repository_name, repository_url });
        }

        public Link GetConfiguration()
        {
            return GetLink(Rels.REPOSITORY_CONFIG_GET, new {repository_name });
        }

        public Link GetTags()
        {
            return GetLink(Rels.REPOSITORY_TAG_GET_LIST, new {repository_name });
        }

        public Link GetTagByName(string tag_name)
        {
            return GetLink(Rels.REPOSITORY_TAG_GET_BY_NAME, new {repository_name, tag_name });
        }

        public Link GetHead()
        {
            return GetLink(Rels.REPOSITORY_HEAD_GET, new {repository_name });
        }

        public Link GetRemotes()
        {
            return GetLink(Rels.REPOSITORY_REMOTE_GET_LIST, new {repository_name });
        }

        public Link GetRemoteByName(string remote_name)
        {
            return GetLink(Rels.REPOSITORY_REMOTE_GET_BY_NAME, new {repository_name, remote_name });
        }

        public Link GetBranches()
        {
            return GetLink(Rels.REPOSITORY_BRANCH_GET_LIST, new {repository_name });
        }

        public Link GetBranchByName(string branch_name)
        {
            return GetLink(Rels.REPOSITORY_BRANCH_GET_BY_NAME, new {repository_name, branch_name });
        }

        public Link GetCommitsByBranchName(string branch_name)
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_LIST_BY_BRANCH_NAME, new {repository_name, branch_name });
        }

        public Link GetCommits()
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_LIST, new {repository_name });
        }

        public Link GetCommitById(string commit_id)
        {
            return GetLink(Rels.REPOSITORY_COMMIT_GET_BY_ID, new {repository_name, commit_id });
        }

        public Link GetTreeById(string tree_id)
        {
            return GetLink(Rels.REPOSITORY_TREE_GET_BY_ID, new {repository_name, tree_id });
        }

        public Link GetBlobById(string blob_id)
        {
            return GetLink(Rels.REPOSITORY_BLOB_GET_BY_ID, new {repository_name, blob_id });
        }

        private Link GetLink(string rel, object values = null)
        {
            return Link.From(rel, _urlHelper.Link(rel, values));
        }
    }
}
