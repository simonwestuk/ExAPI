using ExAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ExAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel data)
        {

            var errorList = new ModelStateDictionary();

            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(data.Email) == null)
                {
                    var user = new IdentityUser();
                    user.Email = data.Email;
                    var result = await _userManager.CreateAsync(user, data.Password);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            errorList.AddModelError(error.Code, error.Description);
                        }

                        return new BadRequestObjectResult(new { Message = "Registration Failed", Errors = errorList });
                    }
                    else
                    {
                        return Ok(new { Message = "Registration Successful" });
                    }
              

                }
                return BadRequest(new { Message = "User Already Registered." });
            }

        }


    }
}
