namespace Git.Web.Apis.Routes
{
    public interface ILinkProvider
    {
        Link GetHome();

        Link GetDocs(string docsPath);

        Link GetCommits();

        Link GetCommitById(string commitId);

        Link GetTreeById(string treeId);

        Link GetBlobById(string blobId);

        Link GetBranches();

        Link GetCommitsByBranchName(string branchName);

        Link GetBranchByName(string branchName);

        Link GetConfiguration();

        Link GetTags();

        Link GetTagByName(string tagName);
    }
}
