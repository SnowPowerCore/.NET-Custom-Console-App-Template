﻿using MinimalStepifiedSystem.Base;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class LaunchContext(Version currentVersion) : BaseGenericContext
{
    public Version CurrentVersion { get; } = currentVersion;
}