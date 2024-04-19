using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IScreen
{
    Task InitAsync();

    void OnScreenAppearing(DictionaryWithDefault<string, object>? args = null);

    void OnScreenDisappearing();
}