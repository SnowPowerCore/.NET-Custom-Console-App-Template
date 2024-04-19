using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Services;

public class ApplicationInfrastructureService(INavigationService navigation,
                                              IConsoleService console,
                                              IResourceService resource) : IApplicationInfrastructureService
{
    public INavigationService Navigation { get; } = navigation;

    public IResourceService Resources { get; } = resource;

    public IConsoleService Console { get; } = console;
}