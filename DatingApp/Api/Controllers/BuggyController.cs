using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }


        // create some methods to return diffrent types of errors
        [Authorize] //this will return 401 unauthorized error
        [HttpGet("auth")]// Get api/buggy/auth
        public ActionResult<string> GetSecret() {
            return "secret text";
        }

        //return not found error
        [HttpGet("not-found")] //Get api/buggy/not-found
        public ActionResult<AppUser> GetNotFound() 
        {
            var thing = _context.Users.Find(-1);
            if(thing == null) return NotFound();// this will return a 404 not found error 
            return Ok(thing);
        }

         //return server error
        [HttpGet("server-error")] //Get api/buggy/server-error
        public ActionResult<string> GetServerError() 
        {
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString(); 
            return thingToReturn;// nullrefurenceexapion 500
        }

           //return bad request error
        [HttpGet("bad-request")] //Get api/buggy/bad-request
        public ActionResult<string> GetBadRequest() 
        {
            return BadRequest("This was not a good request");// 400 bad request
        }
    }
}