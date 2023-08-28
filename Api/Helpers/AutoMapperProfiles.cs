using Api.DTOs;
using Api.Entities;
using Api.Extensions;
using AutoMapper;

namespace Api.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<AppUser, MemberDto>()
        .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.CurrentPhoto).Url))
        .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.BirthDay.CalculateAge()));
      CreateMap<Photo, PhotoDto>();
    }
  }
}