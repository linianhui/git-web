using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public class RepositoryRefSpecResponse
    {
        private RepositoryRefSpecResponse()
        {
        }

        public string destination { get; private set; }

        public RefSpecDirection direction { get; private set; }

        public bool force_update { get; private set; }

        public string source { get; private set; }

        public string specification { get; private set; }

        public static RepositoryRefSpecResponse From(RefSpec refSpec)
        {
            return new RepositoryRefSpecResponse
            {
                destination = refSpec.Destination,
                direction = refSpec.Direction,
                force_update = refSpec.ForceUpdate,
                source = refSpec.Source,
                specification = refSpec.Specification,
            };
        }

        public static List<RepositoryRefSpecResponse> From(IEnumerable<RefSpec> refSpecs)
        {
            return refSpecs.Select(From).ToList();
        }
    }
}
