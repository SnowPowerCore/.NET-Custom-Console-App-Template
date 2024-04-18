using MinimalStepifiedSystem.Attributes;
using #{PROJECT_DEFAULT_NAMESPACE}.Steps.Launch.EveryTime;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class ApplicationInitService : IApplicationInitService
{
    private readonly IVersionTrackingService _versionTracking;

    [StepifiedProcess(Steps = [
        typeof(HandleLaunchErrorsStep),
        typeof(SampleInterceptHttpClientWithHeaderStep),
        typeof(NavigateToRootScreenStep)
    ])]
    protected LaunchDelegate EveryTimeLaunch { get; }

    [ServiceProviderSupplier]
    public ApplicationInitService(IServiceProvider _,
                                  IVersionTrackingService versionTracking)
    {
        _versionTracking = versionTracking;

        _versionTracking.Track();
    }

    public async Task InitAsync()
    {
        var successCurrent = Version.TryParse(_versionTracking.CurrentVersion, out var currentVersion);
        var successPrevious = Version.TryParse(_versionTracking.PreviousVersion, out var previousVersion);

        var launchContext = new LaunchContext(currentVersion!);

        if (_versionTracking.IsFirstLaunchEver)
        {
            //await FirstTimeLaunch(launchContext);
        }

        if (successCurrent && successPrevious && currentVersion!.CompareTo(previousVersion) > 0)
        {
            //await AfterUpdateLaunch(launchContext);
        }

        await EveryTimeLaunch(launchContext);
    }
}