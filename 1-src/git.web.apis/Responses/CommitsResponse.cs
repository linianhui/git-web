using System.Collections.Generic;
using System.Linq;
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
                commits = commits.Select(CommitResponse.From).ToList()
            };
        }

        public override CommitsResponse AddLinks(IUrlHelper urlHelper)
        {
            AddSelf(Routes.Commits.Links.GetAll(urlHelper));
            commits.ForEach(_ => _.AddLinks(urlHelper));
            return this;
        }
    }
}
