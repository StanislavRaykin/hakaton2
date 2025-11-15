using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class EventsController : Controller
    {
        // GET /Events
        public IActionResult Index()
        {
            var now = DateTime.Now;
            var sample = new List<dynamic>
            {
                new { Title = "City Cleanup1", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-10), End = now.AddDays(-9) },
                new { Title = "City Cleanup2", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-7), End = now.AddDays(-6) },
                new { Title = "Recycling Drive", Description = "Bring your recyclables - electronics accepted.", Start = now.AddDays(-1), End = now.AddDays(1) },
                new { Title = "Tree Planting", Description = "Planting native trees along the river.", Start = now.AddDays(3), End = now.AddDays(3) }
            };

            // Ensure Razor resolves the specific view file
            return View("~/Views/Events/Events.cshtml", sample);
        }
    }
}