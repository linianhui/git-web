using System;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class RepositorySignatureResponse
    {
        private RepositorySignatureResponse()
        {
        }

        public string name { get; private set; }

        public string email { get; private set; }

        public DateTimeOffset when { get; private set; }

        public static RepositorySignatureResponse From(Signature signature)
        {
            return new RepositorySignatureResponse
            {
                name = signature.Name,
                email = signature.Email,
                when = signature.When
            };
        }
    }
}
