namespace Git.Web.Apis.Links
{
    public sealed class Link
    {
        private Link()
        {
        }

        public string rel { get; private set; }

        public string herf { get; private set; }

        public static Link From(string rel, string herf)
        {
            return new Link
            {
                rel = rel,
                herf = herf
            };
        }

        public static Link Self(string herf)
        {
            return From("self", herf);
        }
    }
}
