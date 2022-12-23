using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Web;

namespace ASPApp.Models
{
    public class AIModelAPI : IAIModelAPI
    {
        private readonly HttpClient _http = new();
        private readonly string _apiHost;

        public AIModelAPI(string apiHost = "http://127.0.0.1:5000")
        {
            _apiHost = apiHost;
        }

        public ContainerForResultRenameIt GetContainerForResultRenameIt(
            string request, 
            string crdcModelName = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur_classification_CRDC_1000000_1epoch_final",
            string nerModelName = "RuBERT_NER_KNOWLEDGE_SKILLS_100000_3_eps_FINAL",
            string maskModelName = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur",
            int resultCount = 5)
        {
            CrdcDistribution crdc = GetCrdcDistribution(request, crdcModelName);
            List<MaskedTextResultRenameIt> list = new();
            List<MaskFilledText> maskFilledTexts = (List<MaskFilledText>) GetFilledMasks(request, maskModelName);
            foreach (MaskFilledText mft in maskFilledTexts)
            {
                List<NerKsToken> nerKsToneks = (List<NerKsToken>)GetNerTokens(mft.Sequence, nerModelName);
                list.Add(new(crdc, mft, nerKsToneks));
            }
            return new(request, crdc, list);
        }

        public CrdcDistribution GetCrdcDistribution(string request, string modelName)
        {
            var builder = new UriBuilder($"{_apiHost}/model/");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["type"] = "crdc";
            query["name"] = modelName;
            query["request"] = request;
            builder.Query = query.ToString();
            string httpRequestString = builder.ToString();
            string text = GetResponseTextWithHttp(httpRequestString, TimeSpan.FromSeconds(10));
            var result = JsonConvert.DeserializeObject<CrdcDistribution>(text);
            return result is null ? new CrdcDistribution(0.0, 0.0, 0.0, 0.0) : result;
        }

        public IEnumerable<NerKsToken> GetNerTokens(string request, string modelName)
        {
            var builder = new UriBuilder($"{_apiHost}/model/");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["type"] = "ner";
            query["name"] = modelName;
            query["request"] = request;
            builder.Query = query.ToString();
            string httpRequestString = builder.ToString();
            string text = GetResponseTextWithHttp(httpRequestString, TimeSpan.FromSeconds(10));
            var result = JsonConvert.DeserializeObject<List<NerKsToken>>(text);
            return result is null ? new List<NerKsToken>() : result;
        }

        public IEnumerable<MaskFilledText> GetFilledMasks(string request, string modelName)
        {
            if (!request.Contains("[MASK]"))
            {
                return new List<MaskFilledText>() { new MaskFilledText(1.0, "", request) };
            }

            var builder = new UriBuilder($"{_apiHost}/model/");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["type"] = "mask";
            query["name"] = modelName;
            query["request"] = request;
            builder.Query = query.ToString();
            string httpRequestString = builder.ToString();
            string text = GetResponseTextWithHttp(httpRequestString, TimeSpan.FromSeconds(10));
            var result = JsonConvert.DeserializeObject<List<MaskFilledText>>(text);
            return result is null ? new List<MaskFilledText>() : result;
        }

        private string GetResponseTextWithHttp(string request, TimeSpan timeout)
        {
            try
            {
                Task<HttpResponseMessage> httpRequest;
                httpRequest = _http.GetAsync(request);
                if (!httpRequest.Wait(TimeSpan.FromSeconds(10))
                || httpRequest.Result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                var httpResponse = httpRequest.Result;
                return httpResponse.Content.ReadAsStringAsync().Result;
            }
            catch
            {
                return "";
            }
        }
    }
}
