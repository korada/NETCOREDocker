using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerDemo.UI.Models;
using System.Net.Http;

namespace DockerDemo.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpClient client)
        {
            _client = client;
        }

        private readonly HttpClient _client;
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetAsync("/api/values");
            ViewData["result"] = result;
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
