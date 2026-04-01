using Data.Interfaces;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Sedes
{
    public class SedesRepository : ISedesRepository
    {
        private readonly AppDbContext _context;
        public SedesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Sede> GetAll()
        {
            return _context.Sedes.ToList();
        }
        

     }
}
