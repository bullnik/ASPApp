using Newtonsoft.Json;

namespace ASPApp.Models
{
    public class NerKsToken : IAIModelResult
    {
        [JsonProperty("entity_group")]
        public string EntityGroup { get; private set; }

        [JsonProperty("score")]
        public double Score { get; private set; }

        [JsonProperty("word")]
        public string Word { get; private set; }

        [JsonProperty("start")]
        public int StartIndex { get; private set; }

        [JsonProperty("end")]
        public int EndIndex { get; private set; }

        public NerKsToken(string entityGroup, double score, string word, int startIndex, int endIndex) 
        {
            EntityGroup = entityGroup;
            Score = score;
            Word = word;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
