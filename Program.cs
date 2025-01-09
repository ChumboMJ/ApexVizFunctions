using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, config) =>
    {
        var builtConfig = config.Build();
        var keyVaultName = builtConfig["KeyVaultName"];
        if (!string.IsNullOrEmpty(keyVaultName))
        {
            var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
            config.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
        }
    })
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
        .AddMutationType<RaceResultMutation>())
    .Build();

host.Run();