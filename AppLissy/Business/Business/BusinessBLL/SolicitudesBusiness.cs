using Business.Interfaces;
using Data.Interfaces;
using Models.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessBLL
{
    public class SolicitudesBusiness : ISolicitudesBusiness
    {
        private readonly ISolicitudesRepository _solicitudesRepository;
        public SolicitudesBusiness(ISolicitudesRepository isul )
        {
            _solicitudesRepository = isul;
        }

        public List<EstadoSolicitud> GetAll()
        {
            return _solicitudesRepository.GetAll();
        }
    }
}
