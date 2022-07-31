using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

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
     public ActionResult<IEnumerable<AppUser>> GetUsers()
     {
        var users = _context.Users.ToList();
        return users;
     }
     
     [HttpGet("{id}")] // api/user/1
     public ActionResult<AppUser> GetUsers(int id)
     {
        var user = _context.Users.Find(id);
        return user; 
     }

    }
}