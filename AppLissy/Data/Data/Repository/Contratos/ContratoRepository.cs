using Data.Interfaces;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Contratos
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly AppDbContext _context;
        public ContratoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TipoContrato> GetAll()
        {
            var contratos = _context.TipoContratos.ToList();
            return contratos;
        }
    }
}
