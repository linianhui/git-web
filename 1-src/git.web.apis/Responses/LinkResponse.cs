namespace Git.Web.Apis.Responses
{
    public sealed class LinkResponse
    {
        private LinkResponse() { }

        public string rel { get; private set; }

        public string herf { get; private set; }

        public static LinkResponse From(string rel, string herf)
        {
            return new LinkResponse
            {
                rel = rel,
                herf = herf
            };
        }
    }
}
