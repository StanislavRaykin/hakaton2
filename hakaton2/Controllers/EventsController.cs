using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class EventsController : Controller
    {
        // Helper to build the same sample list used by the view.
        private static List<dynamic> GetSampleEvents()
        {
            var now = DateTime.Now;
            return new List<dynamic>
            {
                new { Title = "City Cleanup1", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-10), End = now.AddDays(-9) },
                new { Title = "City Cleanup2", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-7), End = now.AddDays(-6) },
                new { Title = "Recycling Drive", Description = "Bring your recyclables - electronics accepted.", Start = now.AddDays(-1), End = now.AddDays(1) },
                new { Title = "Tree Planting", Description = "Planting native trees along the river.", Start = now.AddDays(3), End = now.AddDays(3) }
            };
        }

        // GET /Events
        public IActionResult Index()
        {
            var sample = GetSampleEvents();
            return View("~/Views/Events/Events.cshtml", sample);
        }

        // GET /Events/Details/{id}
        // id is the zero-based index of the event in the same sample list (for demo).
        public IActionResult Details(int id)
        {
            var sample = GetSampleEvents();
            if (id < 0 || id >= sample.Count) return NotFound();

            var ev = sample[id];
            return View("~/Views/Events/Details.cshtml", ev);
        }
    }
}