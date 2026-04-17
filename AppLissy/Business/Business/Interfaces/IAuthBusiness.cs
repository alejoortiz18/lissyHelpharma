using Models.Dto.Login;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IAuthBusiness
    {
        Task<(bool IsSuccess, string Mensaje, Empleado Usuario)> LoginAsync(LoginDto dto);
    }
}
