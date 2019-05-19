using System.Collections.Generic;
using Git.Web.Apis.Routes;

namespace Git.Web.Apis.Responses
{
    public class HomeResponse : LinkResponse<HomeResponse>
    {
        private ISet<string> _repositoryNames;

        public HomeResponse(ISet<string> repositoryNames)
        {
            _repositoryNames = repositoryNames;
        }

        public override HomeResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetHome());
            AddLink(linkProvider.GetDocs(".docs"));
            foreach (var repositoryName in _repositoryNames)
            {
                AddLink(linkProvider.GetRepositoryHome(repositoryName));
            }
            return this;
        }
    }
}
