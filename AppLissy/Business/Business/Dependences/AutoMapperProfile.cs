using AutoMapper;
using Models.Dto;
using Models.Entities.Domain;

namespace Business.Dependences
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<EventoDto, EventoEmpleado>()
                .ForMember(dest => dest.EventoEmpleadoId, opt => opt.Ignore())
                .ForMember(dest => dest.EmpleadoId, opt => opt.Ignore())
                .ForMember(dest => dest.AutorizadoPorEmpleadoId, opt => opt.Ignore())

                // Navegaciones
                .ForMember(dest => dest.Empleado, opt => opt.Ignore())
                .ForMember(dest => dest.EstadoSolicitud, opt => opt.Ignore())
                .ForMember(dest => dest.TipoEventoEmpleado, opt => opt.Ignore())

                // Fechas automáticas
                .ForMember(dest => dest.FechaRegistro,
                    opt => opt.MapFrom(src => src.FechaRegistro ?? DateTime.Now))

                .ForMember(dest => dest.FechaSolicitud,
                    opt => opt.MapFrom(src => src.FechaSolicitud ?? DateTime.Now));


        }
    }
}