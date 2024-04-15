using Microsoft.ApplicationInsights;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface IApplicationService
{
    IApplicationInfrastructureService Infrastructure { get; }

    TelemetryClient Logging { get; }

    Version AppVersion { get; }

    void Stop();
}