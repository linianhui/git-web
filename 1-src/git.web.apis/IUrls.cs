namespace Git.Web.Apis
{
    public interface IUrls
    {
        string GetHome();

        string GetCommits();

        string GetCommit(string commitId);

        string GetTree(string treeId);

        string GetBlob(string blobId);

        string GetBranches();

        string GetCommitsByBranch(string branchName);
        string GetBranch(string name);
    }
}
