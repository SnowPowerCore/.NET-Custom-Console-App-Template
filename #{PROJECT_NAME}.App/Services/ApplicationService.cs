using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Hosting;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class ApplicationService(IHostApplicationLifetime hostLifetime,
                                IApplicationInfrastructureService applicationInfrastructure,
                                TelemetryClient telemetryClient,
                                IVersionTrackingService versionTracking) : IApplicationService
{
    public IApplicationInfrastructureService Infrastructure { get; } = applicationInfrastructure;

    public TelemetryClient Logging { get; } = telemetryClient;

    public Version AppVersion { get; } = new Version(versionTracking.CurrentVersion);

    public void Stop() =>
        hostLifetime.StopApplication();
}