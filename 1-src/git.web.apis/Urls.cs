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
            public const string GetBlobById = nameof(GetBlobById);
            public const string GetCommits = nameof(GetCommits);
            public const string GetCommitById = nameof(GetCommitById);
            public const string GetTreeById = nameof(GetTreeById);
        }

        public string GetHome()
        {
            return _url.Link(Names.GetHome, null);
        }

        public string GetCommits()
        {
            return _url.Link(Names.GetCommits, null);
        }

        public string GetCommitById(string commitId)
        {
            return _url.Link(Names.GetCommitById, new { commit_id = commitId });
        }

        public string GetTreeById(string treeId)
        {
            return _url.Link(Names.GetTreeById, new { tree_id = treeId });
        }

        public string GetBlobById(string blobId)
        {
            return _url.Link(Names.GetBlobById, new { blob_id = blobId });
        }
    }
}
