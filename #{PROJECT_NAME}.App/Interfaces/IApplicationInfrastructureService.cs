namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IApplicationInfrastructureService
{
    INavigationService Navigation { get; }

    IResourceService Resources { get; }

    IConsoleService Console { get; }
}