namespace ApexVizFunctions
{
    public class ApexVizFunctionsOptions
    {
        public const string ApexVixFunctions = "ApexVizFunctions";
        public CosmosDbOptions CosmosDb { get; set; }

        public class CosmosDbOptions
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
