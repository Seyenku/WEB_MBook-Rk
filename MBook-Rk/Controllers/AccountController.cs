using MBook_Rk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBook_Rk.Controllers
{
    public class AccountController : Controller
    {
        private readonly CustomUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CustomRoleManager _roleManager;

        public AccountController(
            CustomUserManager userManager,
            SignInManager<ApplicationUser> signInManager,
            CustomRoleManager roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Логин и пароль обязательны.");
                return View();
            }
            var user = await _userManager.FindByNameAsync(login);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Profile"); // Перенаправление на личный кабинет
            }
            ModelState.AddModelError("", "Неверный логин или пароль");
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string login, string password, string role)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError("", "Логин, пароль и роль обязательны.");
                return View();
            }

            Console.WriteLine($"DEBUG: Регистрация пользователя {login} с ролью {role}");

            var user = new ApplicationUser { UserName = login };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                Console.WriteLine($"DEBUG: Пользователь {login} успешно создан.");

                // Проверяем, существует ли роль
                var applicationRole = await _roleManager.FindByNameAsync(role);

                if (applicationRole == null)
                {
                    Console.WriteLine($"ERROR: Роль '{role}' не найдена в базе данных!");
                    ModelState.AddModelError("", $"Роль '{role}' не найдена.");
                    return View();
                }

                Console.WriteLine($"DEBUG: Найдена роль {applicationRole.Name}, добавляем пользователю...");
                await _userManager.AddToRoleAsync(user, applicationRole.Name);

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Profile");
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine($"ERROR: {error.Description}");
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}