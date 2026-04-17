using System.Security.Claims;

namespace AppLissy.Common.Security
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;

        public string Nombre => User?.FindFirst(ClaimTypes.Name)?.Value;

        public string Apellido => User?.FindFirst(ClaimTypes.Surname)?.Value;

        public string Email => User?.FindFirst(ClaimTypes.Email)?.Value;

        public int? UsuarioId
        {
            get
            {
                var value = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return int.TryParse(value, out var id) ? id : null;
            }
        }

        public string Rol => User?.FindFirst("Rol")?.Value;

        // 🔥 PRO: helpers
        public bool EsAdmin => Rol == "Admin";
    }
}
