using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public record KnownScreens
{
    public DictionaryWithDefault<string, Type> KnownScreenTypes { get; init; } =
        new(defaultValue: typeof(ScreenBase));

    public Type RootScreenType { get; set; } = typeof(ScreenBase);
}