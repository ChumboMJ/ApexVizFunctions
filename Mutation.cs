using Microsoft.Azure.Cosmos;

namespace ApexVizFunctions
{
    public class Mutation
    {
        private readonly Container _container;

        public Mutation(Container container)
        {
            _container = container;
        }

        public async Task<RaceResult> AddRaceResult(RaceResult raceResult)
        {
            //TODO: Ensure that the PartitionKey is correctly set
            var response = await _container.CreateItemAsync(raceResult, new PartitionKey(raceResult.Class));
            return response.Resource;
        }
    }
}
