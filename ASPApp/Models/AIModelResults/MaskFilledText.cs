using Newtonsoft.Json;

namespace ASPApp.Models
{
    public class MaskFilledText : IAIModelResult
    {
        [JsonProperty("score")]
        public double Score { get; private set; }

        [JsonProperty("token_str")]
        public string Token { get; private set; }

        [JsonProperty("sequence")]
        public string Sequence { get; private set; }

        public MaskFilledText(double score, string token, string sequence) 
        {
            Score= score;
            Token= token;
            Sequence= sequence;
        }
    }
}
