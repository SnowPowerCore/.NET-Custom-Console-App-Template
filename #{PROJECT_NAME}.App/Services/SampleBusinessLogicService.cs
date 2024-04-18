using MinimalStepifiedSystem.Attributes;

namespace #{PROJECT_DEFAULT_NAMESPACE};

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
