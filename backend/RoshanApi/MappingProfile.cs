using AutoMapper;
using RoshanAPI.DTOs;
using RoshanAPI.Models;

namespace RoshanAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
