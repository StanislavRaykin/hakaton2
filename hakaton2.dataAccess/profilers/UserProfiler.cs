using AutoMapper;
using hakaton2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.profilers
{
    public class UserProfiler : Profile
    {
        public UserProfiler()
        {
            CreateMap<UserLoginViewModel, hakaton2.dataAccess.Entities.User>();
        }
    }
}
