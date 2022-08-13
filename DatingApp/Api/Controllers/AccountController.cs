using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Api.Entities;

namespace Api.Controllers
{

    public class AccountController : BaseApiController
    {
         private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")] //Post api/account/register
        public async Task<ActionResult<AppUser>> Register (string username, string password)
        {
         using var hmac = new HMACSHA512();

         var user = new AppUser{
            UserName = username,
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
         };
               _context.Users.Add(user);
               await _context.SaveChangesAsync();
               return user;
        }

      
    }

   
}