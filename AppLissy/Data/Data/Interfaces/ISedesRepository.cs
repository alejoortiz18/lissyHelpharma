using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface ISedesRepository
    {
        List<Sede> GetAll();
    }
}
