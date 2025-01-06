using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace ApexVizFunctions;

public class GraphQLFunction
{
    private readonly IGraphQLRequestExecutor _executor;

    public GraphQLFunction(IGraphQLRequestExecutor executor)
    {
        _executor = executor;
    }

    [Function("ApexVizDataHttpFunction")]
    public Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apex/graphql/{**slug}")]
        HttpRequestData request)
        => _executor.ExecuteAsync(request);
}
