using AutoMapper;
using BCrypt.Net;
using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.interf;
using hakaton2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.dataAccess
{
    public class UserDataAccess : IUserManager
    {
        private hakatonContext db;
        private IMapper mapper;

        public UserDataAccess(hakatonContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> Login(UserLoginViewModel vm)
        {
            bool success = true;
            try
            {
                var foundUser = await db.Users.FirstOrDefaultAsync(u => u.Username == vm.Username);

               if (foundUser != null)
                  {
                    var hashedUserPassword = BCrypt.Net.BCrypt.HashPassword(vm.Password);
                    if (hashedUserPassword != foundUser.Password)
                    {
                        success = false;
                    }
                    // send an incorrect password message
                  }
                else
                    success = false;
            }
            catch(Exception ex) 
            {
                success = false;
            }
            return success;

        }

        //validation needed
        public async Task<bool> Register(UserRegisterViewModel vm)
        {
            bool success = true;
            try
            {
                User user = mapper.Map<User>(vm);
                user.Password = BCrypt.Net.BCrypt.HashPassword(vm.Password);

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
