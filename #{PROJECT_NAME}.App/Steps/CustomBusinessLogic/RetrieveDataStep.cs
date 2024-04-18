using MinimalStepifiedSystem.Interfaces;

namespace #{PROJECT_DEFAULT_NAMESPACE};

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