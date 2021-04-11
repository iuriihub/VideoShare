using VideoShare.Infrastructure.Settings;

namespace VideoShare.Infrastructure.Interfaces
{
    public interface IProxySettings
    {
        string Scheme { get; set; }
        
        string Host { get; set; }

        string Port { get; set; }

        RoutingRuleSetting[] RoutingRules { get; set; }
    }
}
