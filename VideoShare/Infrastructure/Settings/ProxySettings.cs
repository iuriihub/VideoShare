using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Infrastructure.Settings
{
    public class ProxySettings : IProxySettings
    {
        public string Scheme { get; set; }

        public string Host { get; set; }

        public string Port { get; set; }

        public RoutingRuleSetting[] RoutingRules { get; set; }
    }
}
