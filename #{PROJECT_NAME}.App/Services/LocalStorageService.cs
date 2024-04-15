using System.Diagnostics.CodeAnalysis;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class LocalStorageService(Hanssens.Net.ILocalStorage localStorageImpl) : ILocalStorageService
{
    public bool HasKey(string possibleKey) => localStorageImpl.Exists(possibleKey);

    public object Get(string key) => localStorageImpl.Get(key);

    public T? Get<T>(string key) where T : class => localStorageImpl.Get<T>(key) ?? default;

    public void Set<T>([NotNull] string key, T value)
    {
        localStorageImpl.Store(key, value);
        localStorageImpl.Persist();
    }

    public void Clear() => localStorageImpl.Clear();
}