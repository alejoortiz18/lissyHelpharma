using Business.Interfaces;
using Data.Interfaces;
using Models.Dto;
using Models.Models;

namespace Business.BusinessBLL
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly ICargosRepository _cargosRepository;
        private readonly ISedesRepository _sedeRepository;
        private readonly IContratoRepository _tipoContratoRepository;
        private readonly IEmpleadoRespository _empleadoRepository;

        public UsuarioBusiness(ICargosRepository cargo
            , ISedesRepository sede
            , IContratoRepository contrato
            , IEmpleadoRespository emp)
        {
            _cargosRepository = cargo;
            _sedeRepository = sede;
            _tipoContratoRepository = contrato;
            _empleadoRepository = emp;
        }

        public UsuarioCreateData Create()
        {
            var listaCargos = _cargosRepository.GetCargos();
            var listaSedes = _sedeRepository.GetAll();
            var listaContratos = _tipoContratoRepository.GetAll();

            return new UsuarioCreateData
            {
                Cargos = listaCargos,
                Sedes = listaSedes,
                TiposContrato = listaContratos
            };
        }
    }
}
