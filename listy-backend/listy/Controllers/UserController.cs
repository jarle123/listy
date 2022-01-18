using Listy.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Listy.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Listy.Controllers
{
    // TODO:: Implement login
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ListyDbContext _context;
        readonly string TargetHost = "https://localhost:44302";

        public UserController(ListyDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Login([FromBody] UserModel user)
        {
            var Claims = new List<Claim>
            {
                new Claim("type", "Admin"),
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("v$JbXYFX?7RQ3krE?NJ)b$zmN{iNv+{2"));

            var Token = new JwtSecurityToken(
                TargetHost,
                TargetHost,
                Claims,
                expires: DateTime.Now.AddDays(2.0),
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
                );


            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
        }



    }
}
