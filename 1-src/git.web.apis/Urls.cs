using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis
{
    public class Urls : IUrls
    {
        private readonly IUrlHelper _url;

        public Urls(IUrlHelper url)
        {
            _url = url;
        }

        public static class Names
        {
            public const string GetHome = nameof(GetHome);
            public const string GetBlob = nameof(GetBlob);
            public const string GetCommits = nameof(GetCommits);
            public const string GetCommitsByBranch = nameof(GetCommitsByBranch);
            public const string GetCommit = nameof(GetCommit);
            public const string GetTree = nameof(GetTree);
            public const string GetBranches = nameof(GetBranches);
            public const string GetBranch = nameof(GetBranch);
            public const string GetConfiguration = nameof(GetConfiguration);
        }

        public string GetHome()
        {
            return _url.Link(Names.GetHome, null);
        }

        public string GetConfiguration()
        {
            return _url.Link(Names.GetConfiguration, null);
        }

        public string GetBranches()
        {
            return _url.Link(Names.GetBranches, null);
        }

        public string GetBranch(string branch)
        {
            return _url.Link(Names.GetBranch, new { branch = branch });
        }

        public string GetCommitsByBranch(string branch)
        {
            return _url.Link(Names.GetCommitsByBranch, new { branch = branch });
        }

        public string GetCommits()
        {
            return _url.Link(Names.GetCommits, null);
        }

        public string GetCommit(string commitId)
        {
            return _url.Link(Names.GetCommit, new { commitId = commitId });
        }

        public string GetTree(string treeId)
        {
            return _url.Link(Names.GetTree, new { treeId = treeId });
        }

        public string GetBlob(string blobId)
        {
            return _url.Link(Names.GetBlob, new { blobId = blobId });
        }
    }
}
