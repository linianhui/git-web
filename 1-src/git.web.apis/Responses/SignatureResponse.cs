using System;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class SignatureResponse
    {
        private SignatureResponse() { }

        public string name { get; private set; }

        public string email { get; private set; }

        public DateTimeOffset when { get; private set; }

        public static SignatureResponse From(Signature signature)
        {
            return new SignatureResponse
            {
                name = signature.Name,
                email = signature.Email,
                when = signature.When
            };
        }
    }
}
