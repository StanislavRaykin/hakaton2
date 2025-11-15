using hakaton2.dataAccess.dataAccess;
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
    public interface IUserManager
    {
        public Task<bool> Login(UserLoginViewModel vm);

        public Task<bool> Register(UserRegisterViewModel vm);


        
    }
}
