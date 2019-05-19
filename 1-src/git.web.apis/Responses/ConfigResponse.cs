using System.Collections.Generic;
using System.Linq;
using Git.Web.Apis.Routes;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class ConfigResponse : LinkResponse<ConfigResponse>
    {
        private ConfigResponse()
        {
        }

        public IDictionary<string, IDictionary<ConfigurationLevel, string[]>> items { get; private set; }

        public override ConfigResponse AddLinks(ILinkProvider linkProvider)
        {
            AddSelf(linkProvider.GetConfiguration());
            return this;
        }

        public static ConfigResponse From(Configuration configuration)
        {
            ;
            return new ConfigResponse
            {
                items = configuration
                    .GroupBy(k => k.Key)
                    .ToDictionary(kg => kg.Key, GroupByLevel)
            };
        }

        private static IDictionary<ConfigurationLevel, string[]> GroupByLevel(IEnumerable<ConfigurationEntry<string>> entries)
        {
            return entries
                .GroupBy(l => l.Level)
                .ToDictionary(lg => lg.Key, lg => lg.Select(lv => lv.Value).ToArray());
        }
    }
}
