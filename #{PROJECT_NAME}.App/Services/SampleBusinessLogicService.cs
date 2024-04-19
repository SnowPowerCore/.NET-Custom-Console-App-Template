using MinimalStepifiedSystem.Attributes;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Constants;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Context;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Delegates;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Interfaces;
using #{PROJECT_DEFAULT_NAMESPACE}.App.Steps.CustomBusinessLogic;

namespace #{PROJECT_DEFAULT_NAMESPACE}.App.Services;

public class SampleBusinessLogicService : ISampleBusinessLogicService
{
    [StepifiedProcess(Steps = [
        typeof(RetrieveDataStep),
    ])]
    protected SampleBusinessLogicDelegate SampleBusinessLogic { get; }

    [ServiceProviderSupplier]
    public SampleBusinessLogicService(IServiceProvider _) { }

    public async Task<bool> ExecuteStepifiedSampleBusinessLogicAsync()
    {
        var context = new SampleBusinessLogicContext();
        await SampleBusinessLogic.Invoke(context);
        return context.GetFromData<bool>(SampleBusinessLogicConsts.Result);
    }
}
