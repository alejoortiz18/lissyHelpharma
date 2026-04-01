using Models.Entities.Domain;

namespace Data.Interfaces
{
    public interface IContratoRepository
    {
        List<TipoContrato> GetAll();
    }
}
