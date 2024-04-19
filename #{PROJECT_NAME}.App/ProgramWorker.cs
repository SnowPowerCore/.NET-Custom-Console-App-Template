﻿using Microsoft.Extensions.Hosting;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App;

public class ProgramWorker(IHostApplicationLifetime lifetime,
                           IApplicationInitService applicationInit) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!await WaitForAppStartup(lifetime, stoppingToken))
        {
            return;
        }

        _ = Task.Run(applicationInit.InitAsync, stoppingToken);
    }

    private static async Task<bool> WaitForAppStartup(IHostApplicationLifetime lifetime, CancellationToken stoppingToken)
    {
        var startedSource = new TaskCompletionSource();
        var cancelledSource = new TaskCompletionSource();

        using var reg1 = lifetime.ApplicationStarted.Register(startedSource.SetResult);
        using var reg2 = stoppingToken.Register(cancelledSource.SetResult);

        var completedTask = await Task.WhenAny(
            startedSource.Task,
            cancelledSource.Task);

        return completedTask == startedSource.Task; // If a completed task was the "app started" task, return true, otherwise false
    }
}