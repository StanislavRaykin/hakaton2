using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.Interfaces;
using hakaton2.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hakaton2.Controllers
{
    public class EventsController : Controller
    {
        // Helper to build the same sample list used by the view.
        private hakatonContext db;
        private IEventManager _eventManager;
        public EventsController( hakatonContext context, IEventManager eventManager)
        {
            db = context;
            _eventManager = eventManager;
        }   
        //private static List<dynamic> GetSampleEvents()
        //{
        //    var now = DateTime.Now;
        //    return new List<dynamic>
        //    {
        //        new { Title = "City Cleanup1", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-10), End = now.AddDays(-9) },
        //        new { Title = "City Cleanup2", Description = "Community cleanup in downtown parks.", Start = now.AddDays(-7), End = now.AddDays(-6) },
        //        new { Title = "Recycling Drive", Description = "Bring your recyclables - electronics accepted.", Start = now.AddDays(-1), End = now.AddDays(1) },
        //        new { Title = "Tree Planting", Description = "Planting native trees along the river.", Start = now.AddDays(3), End = now.AddDays(3) }
        //    };
        //}

        // GET /Events
        public async Task<IActionResult> Index()
        {
            var top100 = await _eventManager.GetAllEvents();
            return View("~/Views/Events/Events.cshtml", top100);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ev = await _eventManager.GetOne(id);
            return View("~/Views/Events/Details.cshtml", ev);
        }

    }
}