#nullable enable
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace #{PROJECT_DEFAULT_NAMESPACE};

/// <summary>
/// Extension methods for adding and using HttpClientInterceptor.
/// </summary>
public static class HttpClientInterceptorExtension
{
    private static readonly FieldInfo HandlerField = typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.Instance | BindingFlags.NonPublic);

    /// <summary>
    ///  Adds a HttpClientInterceptor service to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    /// </summary>
    /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
    public static void AddHttpClientInterceptor(this IServiceCollection services)
    {
        services.TryAddSingleton(services =>
        {
            var httpClientInterceptor = new HttpClientInterceptor();

            if (HandlerField != null)
            {
                var httpClient = default(System.Net.Http.HttpClient);
                try
                {
                    httpClient = services.GetService<System.Net.Http.HttpClient>();
                }
                catch (InvalidOperationException e) when (e.Source == "Microsoft.Extensions.DependencyInjection" && e.HResult == -2146233079)
                {
                }

                if (httpClient != null)
                {
                    httpClient.EnableIntercept(httpClientInterceptor);
                }
            }

            return httpClientInterceptor;
        });

        services.TryAddSingleton(services =>
        {
            var interceptor = services.GetRequiredService<HttpClientInterceptor>();
            return (IHttpClientInterceptor)interceptor;
        });
    }

    public static System.Net.Http.HttpClient EnableIntercept(this System.Net.Http.HttpClient httpClient, HttpClientInterceptor httpClientInterceptor)
    {
        if (HandlerField?.GetValue(httpClient) is HttpMessageHandler baseHandler && baseHandler is not HttpClientInterceptorHandler)
        {
            var interceptorHandler = new HttpClientInterceptorHandler(httpClientInterceptor, baseHandler);
            HandlerField.SetValue(httpClient, interceptorHandler);
        }
        return httpClient;
    }
}