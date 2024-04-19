using Microsoft.ApplicationInsights;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IApplicationService
{
    IApplicationInfrastructureService Infrastructure { get; }

    TelemetryClient Logging { get; }

    Version AppVersion { get; }

    void Stop();
}