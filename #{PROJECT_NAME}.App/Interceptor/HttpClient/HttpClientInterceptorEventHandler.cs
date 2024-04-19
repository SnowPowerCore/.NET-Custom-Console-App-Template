namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Interceptor.HttpClient;

public delegate Task HttpClientInterceptorEventHandler(object sender, HttpClientInterceptorEventArgs e);