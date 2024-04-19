using MinimalStepifiedSystem.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Constants;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Context;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Delegates;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Steps.CustomBusinessLogic;

public class RetrieveDataStep(IApplicationService application,
                              ISampleApi sampleApi) : IStep<SampleBusinessLogicDelegate, SampleBusinessLogicContext>
{
    public async Task InvokeAsync(SampleBusinessLogicContext context, SampleBusinessLogicDelegate next)
    {
        var data = await sampleApi.GetSampleTextAsync<string>();
        application.Infrastructure.Console.PrintLine(data);
        context.SetDataWith(SampleBusinessLogicConsts.Result, true);
    }
}