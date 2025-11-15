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
                new { Title = "City Cleanup", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-10), End = now.AddDays(-9) },
                new { Title = "Recycling Drive", Description = "Bring your recyclables - electronics accepted.", Start = now.AddDays(-1), End = now.AddDays(1) },
                new { Title = "Tree Planting", Description = "Planting native trees along the river.", Start = now.AddDays(3), End = now.AddDays(3) },
                new { Title = "Composting Workshop", Description = "Learn how to compost at home.", Start = now.AddDays(7), End = now.AddDays(7) },
                new { Title = "Sustainability Fair", Description = "Local vendors and eco-initiatives.", Start = now.AddDays(14), End = now.AddDays(14) }
            };

            // The view file is named Views/Events/Events.cshtml, so specify the view name explicitly.
            return View("Events", sample);
        }
    }
}