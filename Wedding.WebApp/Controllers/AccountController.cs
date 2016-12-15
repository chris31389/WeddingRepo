using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding.WebApp.Authorisation;

namespace Wedding.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [Authorize]
    public class AccountController : Controller
    {
        // private readonly UserManager<User> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            // UserManager<User> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            // _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("login"), HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, IdentityConstants.Password, false, false);
                if (result.Succeeded)
                {
                    return Json("OK");
                }

                return BadRequest();
            }

            return BadRequest();
        }

        [Route("logoff"), HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();

            return Json("OK");
        }
    }
}