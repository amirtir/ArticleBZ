using ArticleBZ.Client.Pages;
using ArticleBZ.Server.Repositories;
using ArticleBZ.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArticleBZ.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private IUserRepository _userRepository;
        public Auth( IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginVM login)
        {
            if (_userRepository.IsUserExsit(login))
            {

                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ValidationKeyApiVerify"));
                var sigingCredentils = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

                var tokenoption = new JwtSecurityToken(
                    issuer: "https://localhost:44376/",
                    expires: System.DateTime.Now.AddMinutes(30),
                    signingCredentials: sigingCredentils,
                claims: new List<Claim>
                {
                   
                    new Claim(ClaimTypes.Email,login.Email),
                    new Claim(ClaimTypes.Name,login.Email),
                    new Claim(ClaimTypes.Role,"Admin")
                }
                    );

                var finaltoken = new JwtSecurityTokenHandler().WriteToken(tokenoption);
                return Ok(new { token = finaltoken });

            }
            else
                return Unauthorized();

        }

    }
}
