using hakaton2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            // TODO: authenticate user against your user store
            return RedirectToAction("Index", "Home");
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            // TODO: create user (check uniqueness, hash password, persist)
            TempData["SuccessMessage"] = "Успешна регистрация. Влезте в профила си.";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
