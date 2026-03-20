using Models.Entities.Domain;

namespace Business.Interfaces
{
    public interface ISolicitudesBusiness
    {
        List<EstadoSolicitud> GetAll();
    }
}
