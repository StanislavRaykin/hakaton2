using hakaton2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.Interfaces
{
    internal interface IEventManager
    {
        Task Create(RequestEventViewModel requesteventVM);
    }
}
