using MinimalStepifiedSystem.Utils;

namespace #{PROJECT_DEFAULT_NAMESPACE};

public class ScreenBase : IScreen
{
    protected DictionaryWithDefault<string, object> CurrentArguments { get; set; } = new(defaultValue: new());

    public DictionaryWithDefault<string, ScreenCommand> Commands { get; private set; }

    public virtual string WelcomeMessage { get; }

    protected IApplicationService Application { get; }

    public ScreenBase(IApplicationService application)
    {
        WelcomeMessage = string.Empty;
        Commands = new(defaultValue: new(AskAgainAsync))
        {
            ["help"] = new(HelpAsync, "Displays a list of available commands with their descriptions."),
            ["exit"] = new(ExitAsync, "Exits the app.")
        };
        Application = application;
    }

    public virtual async Task InitAsync()
    {
        Application.Infrastructure.Console.PrintLine(WelcomeMessage);

        await ReturnToWaitForCommandInputAsync();
    }

    protected virtual async Task HelpAsync()
    {
        OnScreenAppearing();
        PrintCommands();
    }

    protected async Task ExitAsync() => Application.Stop();

    private async Task AskAgainAsync()
    {
        OnScreenAppearing();
    }

    private async Task ReturnToWaitForCommandInputAsync()
    {
        string? input;
        do
        {
            Application.Infrastructure.Console.PrintLine();
            input = Application.Infrastructure.Console.ReadLine();
        }
        while (string.IsNullOrEmpty(input));
        await Commands[input.ToLower()].ExecuteAsync();
        _ = ReturnToWaitForCommandInputAsync();
    }

    public virtual void OnScreenAppearing(DictionaryWithDefault<string, object>? args = null)
    {
        if (args is not default(DictionaryWithDefault<string, object>))
            CurrentArguments = args;

        Application.Infrastructure.Console.New();
    }

    public virtual void OnScreenDisappearing() { }

    public virtual void PrintCommands()
    {
        foreach (var command in Commands)
        {
            Application.Infrastructure.Console.PrintLine($"{command.Key}: {command.Value.Description}");
        }
    }
}