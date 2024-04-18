namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface IApplicationInfrastructureService
{
    INavigationService Navigation { get; }

    IResourceService Resources { get; }

    IConsoleService Console { get; }
}