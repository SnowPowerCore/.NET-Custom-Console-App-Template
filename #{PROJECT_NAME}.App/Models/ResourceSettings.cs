﻿using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class ResourceSettings
{
    public bool UseBase { get; set; } = true;

    public DictionaryWithDefault<Type, string> AdditionalPaths { get; set; } =
        new(defaultValue: string.Empty);
}