using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InternshipsBookApp.AuthRepositoryFolder.Abstract;
using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace InternshipsBookApp.Controllers
{
    public class AuthController : Controller
    {
        private IAuthRepository _authrepository;
        private IUserDal _userDal;
        public AuthController(IAuthRepository authRepository, IUserDal userDal)
        {
            _authrepository = authRepository;
            _userDal = userDal;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _authrepository.Login(username, password);

            if (user == null)
            {
                TempData["Message"] = "Giriş yapılamadı. Lütfen kullanıcı adınızı ve şifrenizi kontrol ediniz.";
                TempData["MessageState"] = "danger";

                return RedirectToAction("Index", "Home");
            }

            var identity = new ClaimsIdentity(new[]
{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                },
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string mail, string name, string surname)
        {
            if (_userDal.UserExist(username))
            {
                TempData["Message"] = "Bu kullanıcı adı zaten kayıtlı.";
                TempData["MessageState"] = "danger";

                return RedirectToAction("Index", "Home");
            }

            User user = new User();
            user.Username = username;
            user.Mail = mail;
            user.Name = name;
            user.Surname = surname;

            var userToReturn = _authrepository.Register(user, password);

            if (userToReturn == null)
            {
                TempData["Message"] = "Kayıt işlemi başarısız oldu.";
                TempData["MessageState"] = "danger";
                
                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = "Kayıt işleminiz başarıyla gerçekleşti";
            TempData["MessageState"] = "info";

            var identity = new ClaimsIdentity(new[]
{
                new Claim(ClaimTypes.Name, userToReturn.Username),
                new Claim(ClaimTypes.NameIdentifier, userToReturn.Id.ToString())
                },
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Index","Home");
        }
    }
}

