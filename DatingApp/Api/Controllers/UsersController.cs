using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Api.interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
        [Authorize]
        public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
   
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        
        }

   
      
        [HttpGet] // api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           var users = await _userRepository.GetUsersAsync();
           return Ok(users);
        }

        
        [HttpGet("{username}")] // api/users/lisa
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            return await _userRepository.GetUserByUserNameAsync(username);
        }
        
    }
}