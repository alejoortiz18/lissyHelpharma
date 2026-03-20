using Data.Interfaces;
using Models.Entities.Domain;

namespace Data.Repository.Solicitudes
{
    public class SolicitudesRepository : ISolicitudesRepository
    {
        private readonly AppDbContext _context;

        public SolicitudesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<EstadoSolicitud> GetAll()
        {
                var solicitudes = _context.EstadoSolicituds.ToList();
                return solicitudes;
        }
    }
}
