using AutoMapper;
using AutoMapper.Demo.Models;
using AutoMapper.Demo.DTOs;

namespace AutoMapper.Demo.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto GetUser(int id)
        {
            // Simulate getting user from database
            var user = new User
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                CreatedAt = DateTime.Now.AddYears(-1),
                Address = new Address { Street = "123 Main St", City = "Anytown" },
            };

            return _mapper.Map<UserDto>(user);
        }

        public User CreateUser(CreateUserDto createUserDto)
        {
            return _mapper.Map<User>(createUserDto);
        }
    }
}