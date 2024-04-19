using MinimalStepifiedSystem.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Context;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Delegates;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Steps.Launch.EveryTime;

public class HandleLaunchErrorsStep(IApplicationService application) : IStep<LaunchDelegate, LaunchContext>
{
    public async Task InvokeAsync(LaunchContext context, LaunchDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            application.Logging.TrackException(ex);
        }
    }
}