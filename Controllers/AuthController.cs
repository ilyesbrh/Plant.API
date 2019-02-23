using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Plant.API.data;
using Plant.API.DTOs;

namespace Plant.API.Controllers {
    /* this annotation is to inform dotnet about the route of this controller */
    [Route ("[controller]")]
    /*this annotation is to inform dotnet that this controller is an API */
    [ApiController]
    public class AuthController : ControllerBase {

        /*this variable allow you to access DB */
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;

        public AuthController (IAuthRepository repo, IConfiguration config) {

            this.repo = repo;
            this.config = config;
        }

        [HttpPost ("Register")]
        /*cant delete [FromForm] even when i used [APIController] */
        public async Task<IActionResult> Register ([FromForm] RegistrationDTO user) {

            /* standardized lower case for all users */
            user.Username = user.Username.ToLower ();
            if (await this.repo.UserExists (user.Username)) {

                return BadRequest ("user Name Taken");
            }

            if (await repo.Register (user.Username, user.Password) != null) {
                return StatusCode (201);
            } else {
                return BadRequest ("Cant create user for some reasons");
            }
        }

        [HttpPost ("Login")]
        public async Task<IActionResult> Login (LoginDTO user) {


            // retrieve user from DB
            var userData = await repo.Login (user.Username.ToLower(), user.Password);
            // see if user exists
            if (userData == null) return Unauthorized ();
            
            /*     Creating token     */

            // INI Claims 
            var claim = new [] {
                new Claim (ClaimTypes.NameIdentifier, userData.Id.ToString ()),
                new Claim (ClaimTypes.Name, userData.UserName.ToString ()),
            };
            // INI key
            //retrieving key from settings
            var key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (config.GetSection ("AppSettings:Token").Value));
            //coding key
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);
            // INI token
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            // token handler to create and write token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            /* return Ok token as response  */
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPut ("/{id}")]
        public void Put (int id, [FromBody] string value) {

        }

    }
}