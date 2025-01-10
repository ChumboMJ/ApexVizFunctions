using ApexVizFunctions.Models;
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
            // Ensure that the ResultId is set
            if (raceResult.ResultId == Guid.Empty)
            {
                raceResult.ResultId = Guid.NewGuid();
            }

            var response = await _container.CreateItemAsync(raceResult, new PartitionKey(raceResult.ResultType));
            return response.Resource;
        }
    }
}
