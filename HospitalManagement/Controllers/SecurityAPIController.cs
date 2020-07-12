using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityAPIController : ControllerBase
    {
        // GET: api/SecurityAPI
        [HttpGet]
   //     public IEnumerable<string> Get()
   //     {

   //         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2525255666665566"));
   //         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

   //         var claims = new[] {
   //         new Claim(JwtRegisteredClaimNames.Sub,"amin"),
   //         new Claim(JwtRegisteredClaimNames.Email,""),
   //         new Claim("Admin","true"),
    //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //        };

    //        var token = new JwtSecurityToken("amin",
      //        "amin",
      //        null,
      //        expires: DateTime.Now.AddMinutes(120),
      //        signingCredentials: credentials);

       //     string tokenString= new JwtSecurityTokenHandler().WriteToken(token);
       //     return new string[] { tokenString };
       // }

        private string GenerateJSONWebToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2525255666665566"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Email,""),
            new Claim("Admin","true"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken("amin",
              "amin",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        // GET: api/SecurityAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SecurityAPI
        [HttpPost]
        public IActionResult Post([FromBody] LoginModel obj)
        {
            if ((obj.UserName == "Amin")&&(obj.Password=="Sohail"))
            {
                obj.token = GenerateJSONWebToken(obj.UserName);
                obj.Password = "";
                return Ok(obj);
            }
            else
            {
                return StatusCode(401, "Unauthorized Crediantial");
            }
        }

        // PUT: api/SecurityAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
