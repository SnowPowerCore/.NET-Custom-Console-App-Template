using MinimalStepifiedSystem.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.Steps.Launch.EveryTime;

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