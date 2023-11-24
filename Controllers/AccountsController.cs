using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using netlectureAPI.DTOs.Accounts;
using netlectureAPI.DTOs.User;

namespace netlectureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(UserManager<IdentityUser> userManager,
                                IConfiguration configuration,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDTO>> Registrar(AccountCredentials credentials)
        {
            var user = new IdentityUser() { UserName = credentials.Email, Email = credentials.Email };
            var result = await userManager.CreateAsync(user, credentials.Password);
            if (result.Succeeded)
            {
                return BuildToken(credentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(AccountCredentials credentials)
        {
            var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password,
            isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(credentials);
            }
            else
            {
                return BadRequest("Email or password incorrect");
            }
        }

        [HttpPost("Renew")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AuthResponseDTO>> Renew()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var user = await userManager.FindByEmailAsync(email);
            var userCredentials = new AccountCredentials()
            {
                Email = email
            };

            return BuildToken(userCredentials);

        }

        private AuthResponseDTO BuildToken(AccountCredentials credentials)
        {
            var claims = new List<Claim>()
            {
                new("email",credentials.Email)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetConnectionString("jwtkey")));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(30);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null,
            expires: expiration, claims: claims, signingCredentials: signingCredentials);

            var response = new AuthResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };

            return response;
        }
    }
}