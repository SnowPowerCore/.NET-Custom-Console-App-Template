using #{PROJECT_DEFAULT_NAMESPACE}.App.Interceptor.HttpClient;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

public interface IHttpClientInterceptor
{
    /// <summary>
    /// Occurs before a HTTP request sending.
    /// </summary>
    event EventHandler<HttpClientInterceptorEventArgs> BeforeSend;

    /// <summary>
    /// Occurs before a HTTP request sending.
    /// </summary>
    event HttpClientInterceptorEventHandler BeforeSendAsync;

    /// <summary>
    /// Occurs after received a response of a HTTP request. (include it wasn't succeeded.)
    /// </summary>
    event EventHandler<HttpClientInterceptorEventArgs> AfterSend;

    /// <summary>
    /// Occurs after received a response of a HTTP request. (include it wasn't succeeded.)
    /// </summary>
    event HttpClientInterceptorEventHandler AfterSendAsync;
}