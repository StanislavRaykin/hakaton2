using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.interf;
using hakaton2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class UserController : Controller
    {
        private IUserManager _userManager;
        private hakatonContext db;
        // GET: /User/Login
        public UserController(IUserManager manager, hakatonContext context)
        {
            _userManager = manager;
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            bool success = await _userManager.Login(login);
            if (success)
            {
               Tem
            }
            // TODO: authenticate user against your user store
            return RedirectToAction("Index", "Home");
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Registration()
        {

            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            // TODO: create user (check uniqueness, hash password, persist)
            if(db.Users.Any(u => u.Username == BCrypt.Net.BCrypt.HashPassword(register.Password)))
            {
                TempData["SuccessMessage"] = "Неуспешнa регистрация. Потребителското име вече се използва";
                return RedirectToAction("Index", "Home");
            }
            bool success = await _userManager.Register(register);
            if (!success)
                TempData["SuccessMessage"] = "Неуспешнa регистрация. Моля опитайте отново";


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
