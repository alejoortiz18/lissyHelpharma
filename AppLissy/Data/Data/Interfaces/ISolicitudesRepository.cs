using Models.Entities.Domain;

namespace Data.Interfaces
{
    public interface ISolicitudesRepository
    {
        List<EstadoSolicitud> GetAll();
    }
}
