using HotChocolate.Types.Relay;
using HotChocolate;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace ApexVizFunctions.Models
{
    public class RaceResult(Guid resultId)
    {
        //TODO: JsonProperty("id") was added to get past an error on insert indicating that id was
        //      a required field, make sure this does not break the fetch
        [GraphQLDescription("Result Id")]
        [ID]
        [JsonProperty("id")]
        public Guid ResultId { get; set; } = resultId;
        public required string ResultType { get; set; }
        public int PaxPosition { get; set; }
        public int ClassPosition { get; set; }
        public required string Class { get; set; }
        public int Number { get; set; }
        public required string Driver { get; set; }
        public required string Car { get; set; }
        public decimal Total { get; set; }
        public decimal Factor { get; set; }
        public decimal PaxTime { get; set; }
        public decimal Diff { get; set; }
        public decimal FromFirst { get; set; }
    }
}
