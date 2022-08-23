using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCRM.Core.Models;
using MovieCRM.Core.Contracts.Service;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace MovieShopMVC.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync accountService;
        private readonly IConfiguration configuration;
        public AccountController(IAccountServiceAsync aser,IConfiguration conf)
        {
            accountService = aser;
            configuration = conf;
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
                foreach(var item in res.Errors)
                {
                    stringBuilder.Append(item.Description);
                }
                return BadRequest(stringBuilder.ToString());
            }
            

        }
        
    }
}
