﻿using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Models;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Screens;

public class MainScreen : ScreenBase
{
    private readonly ISampleBusinessLogicService _sampleBusinessLogic;

    public MainScreen(IApplicationService application,
                      ISampleBusinessLogicService sampleBusinessLogic) : base(application)
    {
        _sampleBusinessLogic = sampleBusinessLogic;

        Commands.Add("q", new(ExitAsync, "Exits the app."));
    }

    protected override async Task InitAsync()
    {
        await base.InitAsync();

        var result = await _sampleBusinessLogic.ExecuteStepifiedSampleBusinessLogicAsync();
        if (result)
        {
            Application.Infrastructure.Console.PrintLine("Logic has been successfully executed.");
        }
    }
}