using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.interfaces;
using API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
        [Authorize]
        public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
   
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

   
      
        [HttpGet] // api/users
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
           var users = await _userRepository.GetMembersAsync();
          
           return Ok(users);
        }

        
        [HttpGet("{username}")] // api/users/lisa
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var rtn = await _userRepository.GetMemberAsync(username);
            //var userToReturn = _mapper.Map<MemberDto>(rtn);
            return rtn;
        }
        
    }
}