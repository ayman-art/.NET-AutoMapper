using AutoMapper;
using AutoMapper.Demo.DTOs;
using AutoMapper.Demo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoMapper.Demo.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.AddressLine,
                    opt => opt.MapFrom(src => $"{src.Address.Street}, {src.Address.City}"))
                .ForMember(dest => dest.MemberSince,
                    opt => opt.MapFrom(src => src.CreatedAt.ToString("MMMM yyyy")));

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}