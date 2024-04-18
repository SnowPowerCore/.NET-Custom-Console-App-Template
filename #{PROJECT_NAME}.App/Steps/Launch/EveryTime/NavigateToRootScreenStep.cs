using MinimalStepifiedSystem.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.Steps.Launch.EveryTime;

public class NavigateToRootScreenStep(INavigationService navigation) : IStep<LaunchDelegate, LaunchContext>
{
    public async Task InvokeAsync(LaunchContext context, LaunchDelegate next)
    {
        await navigation.NavigateToRootAsync();
        await next(context);
    }
}