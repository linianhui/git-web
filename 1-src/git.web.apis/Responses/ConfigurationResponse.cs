using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace Git.Web.Apis.Responses
{
    public sealed class ConfigurationResponse : Links<ConfigurationResponse>
    {
        private ConfigurationResponse() { }

        public IDictionary<string, IDictionary<ConfigurationLevel, string[]>> items { get; private set; }

        public override ConfigurationResponse AddLinks(IUrls urls)
        {
            AddSelf(urls.GetConfiguration());
            return this;
        }

        public static ConfigurationResponse From(Configuration configuration)
        {
            ;
            return new ConfigurationResponse
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
