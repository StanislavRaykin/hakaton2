using AutoMapper;
using hakaton2.dataAccess.Entities;
using hakaton2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.profilers
{
    internal class EventProFiler : Profile
    {
        public EventProFiler()
        {
            CreateMap<RequestEventViewModel, Event>();

        }
    }
}
