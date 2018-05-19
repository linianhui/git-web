using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Extensions;
using Git.Web.Apis.Routes;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace Git.Web.Apis.Responses
{
    public sealed class CommitsResponse : LinksResponse<CommitsResponse>
    {
        private CommitsResponse() { }

        public List<CommitResponse> commits { get; private set; }

        public static CommitsResponse From(IEnumerable<Commit> commits)
        {
            return new CommitsResponse
            {
                commits = commits.ToCommitResponses()
            };
        }

        public override CommitsResponse AddLinks(IUrlHelper url)
        {
            AddSelf(Commits.Links.GetAll(url));
            commits.ForEach(_ => _.AddLinks(url));
            return this;
        }
    }
}
