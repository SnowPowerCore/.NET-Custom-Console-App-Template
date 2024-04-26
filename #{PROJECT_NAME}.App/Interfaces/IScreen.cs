using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IScreen
{
    Task InitScreenAsync();

    Task OnScreenAppearingAsync(DictionaryWithDefault<string, object>? args = null);

    Task OnScreenDisappearingAsync();
}