using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DotNetDemo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtController : ControllerBase
    {
        private readonly IConfiguration _config;

        public JwtController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult getToken()
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken secToken = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public string test()
        {

            return "hello jwt";
        }

    }
}
