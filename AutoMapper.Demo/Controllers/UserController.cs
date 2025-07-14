using Microsoft.AspNetCore.Mvc;
using AutoMapper.Demo.Services;
using AutoMapper.Demo.DTOs;
using AutoMapper.Demo.Models;

namespace AutoMapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public UserDto GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public User CreateUser(CreateUserDto createUserDto)
        {
            return _userService.CreateUser(createUserDto);
        }
    }
}
