using Hanssens.Net;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using #{PROJECT_DEFAULT_NAMESPACE};
using #{PROJECT_DEFAULT_NAMESPACE}.Steps.Launch.EveryTime;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetFileProvider(new EmbeddedFileProvider(typeof(Program).Assembly));
var jsonFiles = Directory.EnumerateFiles("Config", "*.json", SearchOption.AllDirectories);
foreach (var path in jsonFiles)
    builder.Configuration.AddJsonFile(path, optional: true);
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

builder.Services.AddSingleton<ILocalStorage>(sp =>
    new LocalStorage(new LocalStorageConfiguration { AutoLoad = true, AutoSave = true }));
builder.Services.AddSingleton<ILocalStorageService>(sp =>
    new LocalStorageService(sp.GetRequiredService<ILocalStorage>()));
builder.Services.AddSingleton<IResourceService>(sp =>
    new ResourceService(sp.GetRequiredService<IOptions<ResourceSettings>>()));
builder.Services.AddSingleton<IConsoleService>(sp => new ConsoleService());
builder.Services.AddSingleton<INavigationService>(sp =>
    new NavigationService(sp.GetRequiredService<IOptions<KnownScreens>>(),
        sp.GetRequiredService<IServiceProvider>()));
builder.Services.AddSingleton<IApplicationInitService>(sp =>
    new ApplicationInitService(sp, sp.GetRequiredService<IVersionTrackingService>()));
builder.Services.AddSingleton<IApplicationService>(sp =>
    new ApplicationService(sp.GetRequiredService<IHostApplicationLifetime>(),
        sp.GetRequiredService<IApplicationInfrastructureService>(), sp.GetRequiredService<TelemetryClient>(),
        sp.GetRequiredService<IVersionTrackingService>()));
builder.Services.AddSingleton<IApplicationInfrastructureService>(sp =>
    new ApplicationInfrastructureService(sp.GetRequiredService<INavigationService>(),
        sp.GetRequiredService<IConsoleService>(), sp.GetRequiredService<IResourceService>()));
builder.Services.AddSingleton<IVersionTrackingService>(sp =>
    new VersionTrackingService(sp.GetRequiredService<ILocalStorageService>()));
builder.Services.AddSingleton<TelemetryClient>();

builder.Services.AddSingleton(sp => new HandleLaunchErrorsStep(sp.GetRequiredService<IApplicationService>()));
builder.Services.AddSingleton(sp => new NavigateToRootScreenStep(sp.GetRequiredService<INavigationService>()));

builder.Services.AddSingleton(sp => new ScreenBase(sp.GetRequiredService<IApplicationService>()));
builder.Services.AddSingleton(sp => new MainScreen(sp.GetRequiredService<IServiceProvider>(),
    sp.GetRequiredService<IApplicationService>()));

builder.Services.Configure<ResourceSettings>(rs =>
{
    rs.UseBase = true;
});

builder.Services.Configure<KnownScreens>(ks =>
{
    ks.KnownScreenTypes.Add("_default", ks.RootScreenType = typeof(MainScreen));
});

builder.Services.AddOptions();

builder.Services.AddHostedService(sp =>
    new ProgramWorker(sp.GetRequiredService<IHostApplicationLifetime>(),
        sp.GetRequiredService<IApplicationInitService>()));

await builder.Build().RunAsync();