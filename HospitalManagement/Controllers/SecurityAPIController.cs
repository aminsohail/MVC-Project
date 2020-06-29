using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Controllers
{
    [Route("api/SecurityAPI")]
    [ApiController]
    public class SecurityAPIController : ControllerBase
    {
        // GET: api/SecurityAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2525255666665566"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("amin",
              "amin",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            string tokenString= new JwtSecurityTokenHandler().WriteToken(token);
            return new string[] { tokenString };
        }

        // GET: api/SecurityAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SecurityAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
