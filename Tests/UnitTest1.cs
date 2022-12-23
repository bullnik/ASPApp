using ASPApp.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NerKs()
        {
            AIModelAPI api = new();
            var jija = api.GetNerTokens("Знание языка Go", "RuBERT_NER_KNOWLEDGE_SKILLS_100000_3_eps_FINAL");
            Assert.Pass();
        }

        public void IsApiNotThrowExceptions()
        {
            AIModelAPI api = new();
            var jopa = api.GetFilledMasks("сетевой [MASK]", "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur");
            var jija = api.GetNerTokens("Знание языка Go", "RuBERT_NER_KNOWLEDGE_SKILLS_100000_3_eps_FINAL");
            var jiba = api.GetCrdcDistribution("владеть основами программирования", "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur_classification_CRDC_1000000_1epoch_final");
            Assert.Pass();
        }

        public void IsApiNotThrowExceptions2()
        {
            AIModelAPI api = new();
            var jopa = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur";
            var jija = "RuBERT_NER_KNOWLEDGE_SKILLS_100000_3_eps_FINAL";
            var jiba = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur_classification_CRDC_1000000_1epoch_final";
            var boba = api.GetContainerForResultRenameIt("знание языка [MASK]", jiba, jija, jopa);
            Assert.Pass();
        }
    }
}