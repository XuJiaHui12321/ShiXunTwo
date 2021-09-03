using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.JWT
{
       public class JWTService
     {
         #region 依赖注入
         private readonly IConfiguration _configuration;
 
         public JWTService(IConfiguration configuration)
         {
             _configuration = configuration;
         }

        #endregion
         
        #region 方法
         /// <summary>
         /// 获取UserId
         /// </summary>
         /// <param name="UserId"></param>
         /// <returns></returns>
         public string GetToken(string UserId)
         {
              //相关Token的常量
             var claims = new[]
             {
                 new Claim(ClaimTypes.SerialNumber, UserId)
             };
  
             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:SecretKey"]));
               var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
 
             //JWT规定的部分字段
             var token = new JwtSecurityToken(
                 issuer: _configuration["JwtSetting:Issuer"],//提供者
                 audience: _configuration["JwtSetting:Audience"],//被授权者
                 claims: claims,
                 expires: DateTime.Now.AddHours(24),//过期时间
                 signingCredentials: creds
);
 
             string Token = new JwtSecurityTokenHandler().WriteToken(token);
               return Token;
           }

         /// <summary>
         /// 获取当前登录用户ID
         /// </summary>
         /// <param name="User"></param>
         /// <returns></returns>
         public string GetCurrentUserId(ClaimsPrincipal User)
         {
               return User.Claims.SingleOrDefault(t => t.Type ==ClaimTypes.SerialNumber).Value;
          }

        #endregion
     }

}
