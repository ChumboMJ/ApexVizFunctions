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
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        var cosmosDbConnectionString = configuration["ApexVizFunctions:CosmosDb:ConnectionString"];
        var databaseId = configuration["ApexVizFunctions:CosmosDb:DatabaseName"];

        // Add Cosmos DB client
        services.AddSingleton(s =>
        {
            var cosmosClient = new CosmosClient(cosmosDbConnectionString);
            return cosmosClient.GetContainer(databaseId, containerId: "RaceResults");
        });
    })
    .AddGraphQLFunction(b => b
        .AddQueryType<Query>()
        .AddMutationType<RaceResultMutation>())
    .Build();

host.Run();