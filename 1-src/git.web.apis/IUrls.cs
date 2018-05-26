namespace Git.Web.Apis
{
    public interface IUrls
    {
        string GetHome();

        string GetCommits();

        string GetCommitById(string commitId);

        string GetTreeById(string treeId);

        string GetBlobById(string blobId);
    }
}
