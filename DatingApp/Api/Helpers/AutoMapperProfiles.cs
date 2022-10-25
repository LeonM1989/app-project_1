using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Entities;
using Api.Extensions;
using API.DTOs;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
       public AutoMapperProfiles()
        {
            //we want to map AppUser ==> MemberDto//
            CreateMap<AppUser, MemberDto>()
            .ForMember(
                dest => dest.PhotoUrl,
                opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url);
                }
            )
            .ForMember(
                dest => dest.Age,
                opt =>{
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                }
            );

            //we want to mao Photo ==> PhotoDto
            CreateMap<Photo, PhotoDto>();

            //maping MemberUpdateDto => AppUser
            CreateMap<MemberUpdateDTO, AppUser>();
        }
    }
}