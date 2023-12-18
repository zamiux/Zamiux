using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zamiux.Web.Context;
using Zamiux.Web.Entities.User;
using Zamiux.Web.ViewModels.Account;

namespace Zamiux.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor
        private ZamiuxDbContext _context;
        public AccountController(ZamiuxDbContext context)
        {
                _context = context;
        }
        #endregion

        #region Register
        [HttpGet("AdminReg")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("AdminReg")]
        public IActionResult Register(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                // check email is unique
                if (!_context.users.Any(u=>u.UserEmail.Equals(registerUser.UserEmail.ToLower().Trim())))
                {
                    // add user to db
                    var user_data = new User
                    {
                        UserEmail = registerUser.UserEmail.ToLower().Trim(),
                        UserPassword = registerUser.UserPassword,
                        UserStatus = true,
                        EmailActivationCode = Guid.NewGuid().ToString("N")
                    };

                    _context.users.Add(user_data);
                    _context.SaveChanges();

                    // send email activation code

                    // redirect to login page
                    return RedirectToAction("Login","Account", new {areas = ""});
                }
                else
                {
                    ModelState.AddModelError("UserEmail","ایمیل وارد شده تکراری می باشد");
                }


            }
            return View(registerUser);
        }
        #endregion

        #region Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.users.SingleOrDefault(u => u.UserEmail == login.UserEmail.ToLower().Trim());
                if (user != null)
                {
                    if (user.UserPassword == login.UserPassword)
                    {
                        List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.UserEmail)
                    };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        AuthenticationProperties properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };
                        await HttpContext.SignInAsync(principal, properties);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("UserEmail", "نام کاربری یا کلمه عبور اشتباه می باشد");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserEmail", "نام کاربری یا کلمه عبور اشتباه می باشد");
                }
            }
            return View(login);
        }
        #endregion

        #region Logout
        public async Task<IActionResult> LogOut()
        { 
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
        #endregion
    }
}
