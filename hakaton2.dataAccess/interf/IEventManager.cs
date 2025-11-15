using hakaton2.dataAccess.Entities;
using hakaton2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.interf
{
    internal interface IEventManager
    {
        public Task Login(UserLoginViewModel vm);

        public Task Create(Event a);
    }
}
