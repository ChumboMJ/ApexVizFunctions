using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Add Cosmos DB client
        services.AddSingleton(s =>
        {
            var cosmosClient = new CosmosClient("your-cosmos-db-connection-string");
            return cosmosClient.GetContainer("database-id", "container-id");
        });
    })
    .AddGraphQLFunction(b => b
        .AddQueryType<Query>()
        .AddMutationType<Mutation>())
    .Build();

host.Run();
