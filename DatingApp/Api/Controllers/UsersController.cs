using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
     private readonly DataContext _context;
     public UsersController(DataContext context)
     {
        _context = context;
     }
     
     [HttpGet]// api/users
     public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
     {
        var users = await _context.Users.ToListAsync();
        return users;
     }
     
     [HttpGet("{id}")] // api/user/1
     public async Task<ActionResult<AppUser>> GetUsers(int id)
     {
        var user =await _context.Users.FindAsync(id);
        return user; 
     }

    }
}