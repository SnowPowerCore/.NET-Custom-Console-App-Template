namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface IResourceService
{
    string this[string key] { get; }
}