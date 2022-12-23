using Newtonsoft.Json;

namespace ASPApp.Models
{
    public class CrdcDistribution : IAIModelResult
    {
        [JsonProperty("requirements")]
        public double RequirementsScore { get; private set; }

        [JsonProperty("common")]
        public double CommonScore { get; private set; }

        [JsonProperty("duties")]
        public double DutiesScore { get; private set; }

        [JsonProperty("conditions")]
        public double ConditionsScore { get; private set; }

        public CrdcDistribution(double requirementsScore, double commonScore, 
            double dutiesScore, double conditionsScore) 
        { 
            RequirementsScore = requirementsScore;
            CommonScore = commonScore;
            DutiesScore = dutiesScore;
            ConditionsScore = conditionsScore;
        }
    }
}
