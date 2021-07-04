using System.Collections.Generic;
using Git.Web.Apis.Links;

namespace Git.Web.Apis.Responses
{
    public class HomeResponse : LinkResponse<HomeResponse>
    {
        private ISet<string> _repositoryNames;

        public HomeResponse(ISet<string> repositoryNames)
        {
            _repositoryNames = repositoryNames;
        }

        public override HomeResponse WithLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetHome());
            AddLink(linkProvider.GetSwagger(".swagger"));
            AddLink(linkProvider.GetRedoc(".redoc"));
            foreach (var repositoryName in _repositoryNames)
            {
                AddLink(linkProvider.GetRepository(repositoryName));
            }
            AddLink(linkProvider.CloneRepository("git.web", "https://github.com/linianhui/git.web"));
            return this;
        }
    }
}
