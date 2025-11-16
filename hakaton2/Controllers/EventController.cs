using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.Interfaces;
using hakaton2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManager _eventManager;
        public EventController(IEventManager eventManager) 
        { 
        _eventManager = eventManager;
        }

        [HttpGet]
        public IActionResult RequestEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestEvent(RequestEventViewModel requesteventVM)
        {
            if (!ModelState.IsValid)
                return View(requesteventVM);

            if (requesteventVM.Creator == null)
            {
                ModelState.AddModelError("", "Няма въведен име на създател!");
                return View();
            }

            if (requesteventVM.Title == null)
            {
                ModelState.AddModelError("", "Няма въведен име на евент!");
                return View();
            }

            if (requesteventVM.Location == null)
            {
                ModelState.AddModelError("", "Няма въведена локация!");
                return View();
            }
            await _eventManager.Create(requesteventVM);
            //Event event = RequestEventViewModel.RequestEventVMToTrack(requesteventVM);
            //db.Events.Add(event);
            //db.SaveChanges();
            return RedirectToAction("Index", "Events");
        }
    }
}
