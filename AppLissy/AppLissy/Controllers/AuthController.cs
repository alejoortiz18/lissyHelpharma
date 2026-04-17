using Business.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Login;
using System.Security.Claims;

namespace AppLissy.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthBusiness _auth;
        private readonly IEmpleadoBusiness _empBus;
        public AuthController(IAuthBusiness auth, IEmpleadoBusiness empBus)
        {
            _auth = auth;
            _empBus = empBus;
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            _empBus.GenerarPasswords();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InicioSesion(LoginDto dto)
        {
            var result = await _auth.LoginAsync(dto);

            if (!result.IsSuccess)
            {
                ViewData["Error"] = result.Mensaje;
                return View();
            }

            var user = result.Usuario;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nombres),
                new Claim(ClaimTypes.Surname, user.Apellidos),
                new Claim(ClaimTypes.Email, user.Correo ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.EmpleadoId.ToString()),

                // 👇 importante para roles
                new Claim("Rol", "Admin") // luego lo sacamos de DB
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8)
                });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("InicioSesion");
        }

    }
}
