using Data.Interfaces;
using Models.Entities.Domain;


namespace Data.Repository.Cargos
{
    public class CargosRepository : ICargosRepository
    {
        private readonly AppDbContext _context;
        public CargosRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cargo> GetCargos()
        {
            return _context.Cargos.ToList();
        }

    }
}
