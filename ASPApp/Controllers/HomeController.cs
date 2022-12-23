using ASPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAIModelAPI _aiModelAPI;

        public HomeController(ILogger<HomeController> logger, IAIModelAPI aiModelAPI)
        {
            _logger = logger;
            _aiModelAPI = aiModelAPI;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MaskSuggestions(string request,
            string crdcModelName = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur_classification_CRDC_1000000_1epoch_final",
            string nerModelName = "RuBERT_NER_KNOWLEDGE_SKILLS_100000_3_eps_FINAL",
            string maskModelName = "final_model_DeepPavlov_rubert-base-cased-finetuned-vacancies_5epoch_300k_-timur",
            int resultCount = 5)
        {
            request = request.Replace("JIBAJIBAJIBA", " ");
            var result = _aiModelAPI.GetContainerForResultRenameIt(request, 
                crdcModelName, nerModelName, maskModelName, resultCount);
            return PartialView("MaskFillingSuggestions", result);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}