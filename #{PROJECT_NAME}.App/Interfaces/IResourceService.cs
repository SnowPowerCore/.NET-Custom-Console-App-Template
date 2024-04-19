namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IResourceService
{
    string this[string key] { get; }
}