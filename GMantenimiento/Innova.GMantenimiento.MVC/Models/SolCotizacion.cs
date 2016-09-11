using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innova.GMantenimiento.MVC.Models
{
    public class SolCotizacion
    {
        public int CodSolCotizacion { get; set; }

        public DateTime? FechaCotizacion { get; set; }

        public int? CodSolAdquisicion { get; set; }

        public int? CodProveedor { get; set; }

        public string CodEstado { get; set; }
    }
}