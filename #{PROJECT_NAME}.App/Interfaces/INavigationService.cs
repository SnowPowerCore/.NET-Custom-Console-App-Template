using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface INavigationService
{
    Task NavigateToRootAsync(DictionaryWithDefault<string, object>? additionalData = null);

    Task NavigateToScreenAsync(string screenName, DictionaryWithDefault<string, object>? additionalData = null);

    Task NavigateBackAsync();
}