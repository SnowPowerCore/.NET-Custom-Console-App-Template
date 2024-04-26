using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MinimalStepifiedSystem.Utils;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Models;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Services;

public class NavigationService(IOptions<KnownScreens> knownScreens,
                               IServiceProvider serviceProvider) : INavigationService
{
    private readonly IList<IScreen> _screenStack = [];

    public Task NavigateToRootAsync(DictionaryWithDefault<string, object>? additionalData = null)
    {
        _screenStack.Clear();
        return NavigateToScreenAsync("_default", additionalData);
    }

    public async Task NavigateToScreenAsync(string screenName, DictionaryWithDefault<string, object>? additionalData = null)
    {
        var screenType = knownScreens.Value.KnownScreenTypes[screenName];
        var screen = (IScreen)serviceProvider.GetRequiredService(screenType);
        await screen.OnScreenAppearingAsync(additionalData);
        await screen.InitScreenAsync();
        _screenStack.Add(screen);
    }

    public async Task NavigateBackAsync()
    {
        var lastScreen = _screenStack.LastOrDefault();
        if (lastScreen is default(IScreen))
            return;

        await lastScreen.OnScreenDisappearingAsync();
        _screenStack.Remove(lastScreen);

        var newLastScreen = _screenStack.LastOrDefault();
        if (newLastScreen is default(IScreen))
            return;

        await newLastScreen.OnScreenAppearingAsync();
        await newLastScreen.InitScreenAsync();
    }
}