using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Entities;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
       public AutoMapperProfiles()
        {
            //we want to map AppUser ==> MemberDto
            CreateMap<AppUser, MemberDto>();

            //we want to mao Photo ==> PhotoDto
            CreateMap<Photo, PhotoDto>();
        }
    }
}