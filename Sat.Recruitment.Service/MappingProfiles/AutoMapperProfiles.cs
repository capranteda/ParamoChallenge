

using AutoMapper;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Model.DTOs;


namespace Sat.Recruitment.Service.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
        }
    }
}