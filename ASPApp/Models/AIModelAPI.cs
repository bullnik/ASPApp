using Newtonsoft.Json;

namespace ASPApp.Models
{
    public class AIModelAPI : IAIModelAPI
    {
        private readonly HttpClient _http = new();
        private string apiHost = "http://127.0.0.1:5000";

        public AIModelAPI()
        {

        }

        public IEnumerable<DirectionSearchResult> GetDirections(string request)
        {
            string httpRequestString = $"{apiHost}/dir/{request}";
            string text = GetResponseTextWithHttp(httpRequestString, TimeSpan.FromSeconds(10));
            var result = JsonConvert.DeserializeObject<List<DirectionSearchResult>>(text);
            return result is null ? new List<DirectionSearchResult>() : result;
        }

        public IEnumerable<RequirementSearchResult> GetRequirements(string request)
        {
            string httpRequestString = $"{apiHost}/req/{request}";
            string text = GetResponseTextWithHttp(httpRequestString, TimeSpan.FromSeconds(10));
            var result = JsonConvert.DeserializeObject<List<RequirementSearchResult>>(text);
            return result is null ? new List<RequirementSearchResult>() : result;
        }

        private string GetResponseTextWithHttp(string request, TimeSpan timeout)
        {
            Task<HttpResponseMessage> httpRequest;
            try
            {
                httpRequest = _http.GetAsync(request);
                if (!httpRequest.Wait(TimeSpan.FromSeconds(10))
                || httpRequest.Result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                var httpResponse = httpRequest.Result;
                return httpResponse.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
