using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieCRM.Core.Contracts.Service;
using MovieCRM.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync accountService;
        private readonly IConfiguration configuration;
        public AccountController(IAccountServiceAsync aser, IConfiguration configuration)
        {
            accountService = aser;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await accountService.SignUpAsync(model);
            if (res.Succeeded)
            {
                return Ok(new { Message = "User Created Successfully" });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in res.Errors)
                {
                    stringBuilder.Append(item.Description);
                }
                return BadRequest(stringBuilder.ToString());
            }


        }
        [HttpPost("login")]

        public async Task<IActionResult> LoginAsync(SignInModel model)
        {
            var result = await accountService.SignInAsync(model);
            if (!result.Succeeded)
            {
                return Unauthorized(new { Message = "Invalid Username or PassWord" });
            }
            else
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.Email),
                    new Claim(ClaimTypes.Country,"USA"),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                    );
                var t = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { jwt = t });
            }
        }
    }
}
