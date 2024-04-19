using MinimalStepifiedSystem.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Context;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Delegates;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interceptor.HttpClient;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Steps.Launch.EveryTime;

public class SampleInterceptHttpClientWithHeaderStep : IStep<LaunchDelegate, LaunchContext>
{
    public SampleInterceptHttpClientWithHeaderStep(IHttpClientInterceptor httpClientInterceptor)
    {
        httpClientInterceptor.BeforeSendAsync += HttpClientBeforeSendAsync;
    }

    public Task InvokeAsync(LaunchContext context, LaunchDelegate next) => next(context);

    private async Task HttpClientBeforeSendAsync(object sender, HttpClientInterceptorEventArgs e)
    {
        e.Request.Headers.Add("X-Test", "test");
    }
}