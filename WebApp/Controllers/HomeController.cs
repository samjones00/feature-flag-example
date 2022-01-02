using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManager _featureManager;

        public HomeController(ILogger<HomeController> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            if (await _featureManager.IsEnabledAsync(FeatureFlags.FeatureB))
            {
                ViewBag.FeatureB = $"{FeatureFlags.FeatureB} enabled!";
            }

            return View();
        }

        [FeatureGate(FeatureFlags.FeatureC)]
        public IActionResult FeatureC()
        {
            return Content($"{FeatureFlags.FeatureC} enabled!");
        }
    }
}
