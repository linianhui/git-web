namespace Git.Web.Apis.Links
{
    public interface ILinkProvider
    {
        Link GetHome();

        Link GetSwagger(string docsPath);

        Link GetRedoc(string docsPath);

        Link GetRepository();

        Link GetRepository(string repository_name);

        Link CloneRepository(string repository_name, string repository_url);

        Link GetCommits();

        Link GetCommitById(string commit_id);

        Link GetTreeById(string tree_id);

        Link GetBlobById(string blob_id);

        Link GetBranches();

        Link GetCommitsByBranchName(string branch_name);

        Link GetBranchByName(string branch_name);

        Link GetConfiguration();

        Link GetTags();

        Link GetTagByName(string tag_name);

        Link GetHead();

        Link GetRemotes();

        Link GetRemoteByName(string remote_name);
    }
}
