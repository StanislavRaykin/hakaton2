using hakaton2.Models;
using hakaton2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.Interfaces
{
    public interface IEventManager
    {
        Task Create(RequestEventViewModel requesteventVM);

        Task<List<EventViewModel>> GetAllEvents();

        Task<EventViewModel> GetOne(int id);
    }
}
