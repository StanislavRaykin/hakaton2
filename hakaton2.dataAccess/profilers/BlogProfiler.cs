using AutoMapper;
using hakaton2.dataAccess.Entities;
using hakaton2.Models;
using hakaton2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.profilers
{
    public class BlogProfiler : Profile
    {
        public BlogProfiler()
        {
            CreateMap<BlogViewModel, Blog>().ReverseMap();
        }
    }
}
