using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using WTechAuth.Data;
using WTechAuth.Models;

namespace WTechAuth.Controllers
{
    public class CarbonCalculatorController : Controller
    {

        private readonly WTechAuthDbContext _context;
        public DbSet<SummativeResult> SummativeResults { get; set; }

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
 
        // Method to fetch emission factors from the database
        public IActionResult MobileCombustion()
        {
            return View();

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
        public IActionResult Transportationofgoods()
        {

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

        [HttpPost]
        public IActionResult SaveEmissions([FromBody] Root emissionsData)
        {
            
            var resultsToSave = new List<SummativeResult>();

            var userId = HttpContext.Session.GetString("UserId"); // Retrieve UserId from session

            foreach (var emission in emissionsData.emissionsData)
            {
                // You may want to validate categories, etc. before saving
                resultsToSave.Add(new SummativeResult
                {
                    UserId = "123",
                    Scope = "S-1", // Adjust according to your requirements
                    Category = emission.category,
                    Result = Convert.ToDecimal(emission.result),
                    DateTime = DateTime.Now // Adjust according to your requirements
                });
            }

            if (resultsToSave.Count > 0)
            {
                try
                {
                    _context.SummativeResults.AddRange(resultsToSave);
                    _context.SaveChanges();
                    return Json(new { success = true, message = "Emissions saved successfully!" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error saving emissions.", error = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "No valid emissions data to save." });
            }
        }


    }
}   
