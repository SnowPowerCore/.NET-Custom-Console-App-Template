using Refit;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public interface ISampleApi
{
    [Get("/api/plaintext")]
    Task<TResult> GetSampleTextAsync<TResult>();
}