using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WTechAuth.Data;
using WTechAuth.Models;

namespace WTechAuth.Controllers
{
    public class CarbonCalculatorController : Controller
    {

        private readonly WTechAuthDbContext _context;

        public CarbonCalculatorController(WTechAuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var currentYear = DateTime.Now.Year;
            var years = new List<int>();

            for (int i = currentYear; i >= 2015; i--)  // Reverse order: latest first
            {
                years.Add(i);
            }

            // Pass the year list to the view
            ViewBag.Years = years;
            ViewBag.SelectedYear = currentYear; // Preselect the current year

            return View();
        }
        [HttpPost]

        // Method to fetch emission factors from the database
        public IActionResult MobileCombustion()
        {

            var mobileCombustionFactors = _context.MobileCombustion.ToList();
            ViewBag.FactorList = mobileCombustionFactors; // Passing to ViewBag
            return View(mobileCombustionFactors); // Or passing to Model
        }

        [HttpPost]

        public IActionResult StationaryCombustion()
        {
            return View();
        }

        public IActionResult DeliveryVehicle()
        {
            return View();
        }
        public IActionResult FugitiveEmissions()
        {
            return View();
        }
        public IActionResult ElectricityHeating()
        {
            return View();
        }
        public IActionResult Transportation()
        {
            return View();
        }
        public IActionResult Businessairtravel()
        {
            return View();
        }
        public IActionResult Transportationofgoods() { 

            return View();
        }
        public IActionResult Wastedisposal()
        {

            return View();
        }
        public IActionResult Watersupply()
        {

            return View();
        }
        public IActionResult Watertreatment()
        {

            return View();
        }

        public IActionResult Submit(CarbonCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("StepThree", model);
        }
    }
}
