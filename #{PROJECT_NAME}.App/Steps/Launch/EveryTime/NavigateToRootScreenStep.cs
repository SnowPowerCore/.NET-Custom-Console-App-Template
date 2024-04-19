using MinimalStepifiedSystem.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Context;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Delegates;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Steps.Launch.EveryTime;

public class NavigateToRootScreenStep(INavigationService navigation) : IStep<LaunchDelegate, LaunchContext>
{
    public async Task InvokeAsync(LaunchContext context, LaunchDelegate next)
    {
        await navigation.NavigateToRootAsync();
        await next(context);
    }
}