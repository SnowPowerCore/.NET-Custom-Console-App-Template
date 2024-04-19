using Refit;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface ISampleApi
{
    [Get("/api/plaintext")]
    Task<TResult> GetSampleTextAsync<TResult>();
}