using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WTechAuth.Areas.Identity.Data;
using WTechAuth.Models;
using WTechAuth.Data;

namespace WTechAuth.Controllers
{
    [Authorize  ]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WTechAuthDbContext _context;


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, WTechAuthDbContext context)
        {
            _logger = logger;
            this._userManager = userManager;
            _context = context;


        }

        public IActionResult Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);

            // Get the latest data for each category within Scope S-1
            var latestScope1Data = _context.SummativeResults
                .Where(r => r.Scope == "S-1")
                .ToList() // Retrieve all relevant data first
                .GroupBy(r => r.Category)
                .Select(g => g.OrderByDescending(r => r.DateTime).FirstOrDefault())
                .ToList();

            var mobileCombustion = latestScope1Data.FirstOrDefault(r => r?.Category == "MobileCombustion")?.Result ?? 0;
            var stationaryCombustion = latestScope1Data.FirstOrDefault(r => r?.Category == "StationaryCombustion")?.Result ?? 0;
            var processEmission = latestScope1Data.FirstOrDefault(r => r?.Category == "ProcessEmission")?.Result ?? 0;
            var refrigerantEmissions = latestScope1Data.FirstOrDefault(r => r?.Category == "RefrigerantEmissions")?.Result ?? 0;

            // Calculate total CO2-equivalent emissions for Scope 1
            var totalCO2Eq = mobileCombustion + stationaryCombustion + processEmission + refrigerantEmissions;

            // Assign the total CO2-equivalent to ViewData
            ViewData["TotalCO2Eq"] = totalCO2Eq;

            // Assign individual values to ViewData for the chart
            ViewData["MobileCombustion"] = mobileCombustion;
            ViewData["StationaryCombustion"] = stationaryCombustion;
            ViewData["ProcessEmission"] = processEmission;
            ViewData["RefrigerantEmissions"] = refrigerantEmissions;

            return View();
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
