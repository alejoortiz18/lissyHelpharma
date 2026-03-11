using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Paginacion<T>
    {
        public List<T> Datos { get; set; }

        public int TotalRegistros { get; set; }

        public int PaginaActual { get; set; }

        public int RegistrosPorPagina { get; set; }

        public int TotalPaginas =>
            (int)Math.Ceiling((double)TotalRegistros / RegistrosPorPagina);
    }
}
