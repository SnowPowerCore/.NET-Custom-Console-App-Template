using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Models;

public class JsonLocalization
{
    public string Key { get; set; } = string.Empty;

    public DictionaryWithDefault<string, string> LocalizedValues { get; set; } = [];
}