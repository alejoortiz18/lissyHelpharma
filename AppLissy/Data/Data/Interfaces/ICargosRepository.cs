using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface ICargosRepository
    {
        List<Cargo> GetCargos();
    }
}
