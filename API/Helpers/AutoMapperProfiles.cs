using System;
using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x => x.IsMain).Url))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom( src => 
                    DateTime.Now.Year - src.DateOfBirth.Year));
            CreateMap<Photo, PhotoDto>();
        }
    }
}