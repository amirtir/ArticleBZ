using ArticleBZ.Server.Repositories;
using ArticleBZ.Shared.DTOs;
using ArticleBZ.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ArticleBZ.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create( [FromBody] UserVM user)
        {
         
            var _user = _userRepository.Create(user);
            return Ok(_user);

        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
           var result=_userRepository.GetAllUsers();
            return Ok(result);
        }

      
    }
}
