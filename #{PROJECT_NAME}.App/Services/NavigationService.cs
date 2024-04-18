using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE};

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
        screen.OnScreenAppearing(additionalData);
        await screen.InitAsync();
        _screenStack.Add(screen);
    }

    public async Task NavigateBackAsync()
    {
        var lastScreen = _screenStack.LastOrDefault();
        if (lastScreen is default(IScreen))
            return;

        lastScreen.OnScreenDisappearing();
        _screenStack.Remove(lastScreen);

        var newLastScreen = _screenStack.LastOrDefault();
        if (newLastScreen is default(IScreen))
            return;

        newLastScreen.OnScreenAppearing();
        await newLastScreen.InitAsync();
    }
}