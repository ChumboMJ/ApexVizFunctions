using Microsoft.Azure.Cosmos;

namespace ApexVizFunctions
{
    public class RaceResultMutation
    {
        private readonly Container _container;

        public RaceResultMutation(Container container)
        {
            _container = container;
        }

        public async Task<RaceResult> AddRaceResultAsync(RaceResult raceResult)
        {
            //TODO: Ensure that the PartitionKey is correctly set
            var response = await _container.CreateItemAsync(raceResult, new PartitionKey(raceResult.Class));
            return response.Resource;
        }
    }
}
