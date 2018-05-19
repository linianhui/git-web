using System;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class UserResponse
    {
        private UserResponse() { }

        public string name { get; private set; }

        public string email { get; private set; }

        public DateTimeOffset when { get; private set; }

        public static UserResponse From(Signature signature)
        {
            return new UserResponse
            {
                name = signature.Name,
                email = signature.Email,
                when = signature.When
            };
        }
    }
}
