using Models.Entities.Domain;
namespace Models.Dto
{
    public class UsuarioCreateData
    {
        public List<Cargo> Cargos { get; set; }
        public List<Sede> Sedes { get; set; }
        public List<TipoContrato> TiposContrato { get; set; }

        public UsuarioCreateData()
        {
            Cargos = new List<Cargo>();
            Sedes = new List<Sede>();
            TiposContrato = new List<TipoContrato>();
        }
    }
}
