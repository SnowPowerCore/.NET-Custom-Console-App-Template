using MinimalStepifiedSystem.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.Steps.Launch.EveryTime;

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