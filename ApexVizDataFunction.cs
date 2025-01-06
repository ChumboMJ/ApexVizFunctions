using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace ApexVizFunctions;

public class ApexVizDataFunction
{
    private readonly IGraphQLRequestExecutor _executor;

    public ApexVizDataFunction(IGraphQLRequestExecutor executor)
    {
        _executor = executor;
    }

    [Function("ApexVizDataHttpFunction")]
    public Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apex/graphql/{**slug}")]
        HttpRequestData request)
        => _executor.ExecuteAsync(request);
}
