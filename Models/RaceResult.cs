using HotChocolate.Types.Relay;
using HotChocolate;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApexVizFunctions.Models
{
    public class RaceResult(Guid resultId)
    {
        [GraphQLDescription("Result Id")]
        [ID]
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
