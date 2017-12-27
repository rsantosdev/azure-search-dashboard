using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AzureSearchDashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzureSearchDashboard.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IOptions<AuthSettings> _authOptions;

        public AccountController(IOptions<AuthSettings> authOptions)
        {
            _authOptions = authOptions;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> PostLogin()
        {
            if (_authOptions.Value.AuthUsername == Request.Form["Username"]
                && _authOptions.Value.AuthPassword == Request.Form["Password"])
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Request.Form["Username"])
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }

            return PartialView("login");
        }
    }
}
