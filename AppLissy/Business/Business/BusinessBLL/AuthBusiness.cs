using Business.Interfaces;
using Data.Interfaces;
using Helper;
using Models.Dto.Login;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessBLL
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly IEmpleadoRespository _repo;

        public AuthBusiness(IEmpleadoRespository repo)
        {
            _repo = repo;
        }

        public async Task<(bool IsSuccess, string Mensaje, Empleado Usuario)> LoginAsync(LoginDto dto)
        {
            var empleado = await _repo.ObtenerPorCorreo(dto.Email);

            if (empleado == null)
                return (false, "Usuario no existe", null);

            if (!empleado.Activo)
                return (false, "Usuario inactivo", null);

            if (empleado.PasswordHash == null || empleado.PasswordSalt == null)
                return (false, "Usuario sin credenciales", null);

            bool passwordValido = PasswordHelper.VerificarPassword(
                dto.Password,
                empleado.PasswordHash,
                empleado.PasswordSalt
            );

            if (!passwordValido)
                return (false, "Contraseña incorrecta", null);

            return (true, "OK", empleado);
        }
    }
}
