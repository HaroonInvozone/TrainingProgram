using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto) 
        {
            CreatePasswordHash(userDto.Password, out byte[] passwordhash, out byte[] passwordSalt);

            user.UserName = userDto.UserNamae;
            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordSalt;
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            //just check only the current user
            if (user.UserName != userDto.UserNamae)
                return BadRequest("User name not found");
            if (!VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("The password was incorrect");
            var token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            try {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordhash,out byte[] passwordSalt) 
        {
            using (var hmac = new HMACSHA512() ) 
            {
                passwordSalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var Computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Computedhash.SequenceEqual(passwordhash);
            }
        }

    }
}
