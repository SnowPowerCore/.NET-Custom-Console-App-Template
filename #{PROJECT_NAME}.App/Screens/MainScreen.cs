using MinimalStepifiedSystem.Attributes;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class MainScreen : ScreenBase
{
    [ServiceProviderSupplier]
    public MainScreen(IServiceProvider _,
                      IApplicationService application) : base(application)
    {
        Commands.Add("q", new(ExitAsync, "Exits the app."));
    }

    private async Task AskAndScanPdfAsync()
    {
        OnScreenAppearing();
    }

    private async Task GenerateSourceImagesAsync()
    {
        OnScreenAppearing();
    }

    private async Task GeneratePartsImagesAsync()
    {
        OnScreenAppearing();
    }
}