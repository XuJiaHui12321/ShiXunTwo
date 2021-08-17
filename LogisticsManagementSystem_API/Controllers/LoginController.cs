using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagementSystem_IDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using LogisticsManagementSystem_MODEL;
using NLog;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LogisticsManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JwtConfig jwtconfig;
        private IUser user;
        private ILogger<LoginController> logger;
        public LoginController(IOptions<JwtConfig> option,IUser _user,ILogger<LoginController> _logger)
        {
            jwtconfig = option.Value;
            user = _user;
            logger = _logger;
        }
        [HttpGet]
        public ActionResult<string> LoginVerification(string Name="",string PassWord="")
        {
            UserModel userModel= user.UserLogin(Name,PassWord);
            if (userModel==null)
            {
                return "登陆失败";
            }
            logger.LogError("12");
            var claim = new Claim[]{
            new Claim("UserName", "lb")
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtconfig.Issuer,
                audience: jwtconfig.Audience,
                claims: claim,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token),UserId=userModel.UserId });
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return "value";
        }
        [Authorize]

        [HttpGet("GetUser")]
        public ActionResult GetUser(int UserId)
        {
            UserModel userModel = user.UserLogin(UserId);
            return Ok(userModel);
        }
        
    }
}
