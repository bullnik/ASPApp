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

        public IActionResult SearchRequirement(string request)
        {
            var result = _aiModelAPI.GetRequirements("JIBA");
            return PartialView("RequirementSearchResult", result);
        }

        public IActionResult SearchDirection(string request)
        {
            var result = _aiModelAPI.GetDirections(request);
            return PartialView("DirectionSearchResult", result);
        }

        public IActionResult Privacy()
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