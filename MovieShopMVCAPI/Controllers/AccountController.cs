using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync accountService;
        public AccountController(IAccountServiceAsync aser)
        {
            accountService = aser;
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
    }
}
