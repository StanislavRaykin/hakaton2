using AutoMapper;
using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.Interfaces;
using hakaton2.Models;
using hakaton2.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.data.Access
{
    public class EventManager : IEventManager
    {
        private readonly IMapper _mapper;
        private readonly hakatonContext _hacatoncontext;
        public EventManager(hakatonContext hakatonContext, IMapper mapper) 
        { 
          _hacatoncontext = hakatonContext;
            _mapper = mapper;
        }
        public async Task Create(RequestEventViewModel requesteventVM)
        {
            Event eventDb = _mapper.Map<Event>(requesteventVM);
            eventDb.CreatedOn = DateTime.Now;
            await _hacatoncontext.Events.AddAsync(eventDb);
            await _hacatoncontext.SaveChangesAsync();
        }

        public async Task<List<EventViewModel>> GetAllEvents()
        {
            var top100 = await _hacatoncontext.Events.Take(100)
                .OrderBy(e => e.Start)
                .ToListAsync() ?? new List<Event>();

            List<EventViewModel> eventVMs = _mapper.Map<List<EventViewModel>>(top100);
            return eventVMs;
        }

        public async Task<EventViewModel> GetOne(int id)
        {
            var ev = await _hacatoncontext.Events.FindAsync(id);
            EventViewModel evVM = _mapper.Map<EventViewModel>(ev);
            return evVM;
        }
    }
}
