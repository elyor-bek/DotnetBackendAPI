using AutoMapper;
using DotnetBackendAPI.DTOs;
using DotnetBackendAPI.Models;

namespace DotnetBackendAPI;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User,UserDto>();
        CreateMap<AddUserDto,User>();
    }
}
