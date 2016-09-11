using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innova.GMantenimiento.MVC.Models
{
    public class Cotizacion
    {
        public int? CodSolCotizacion { get; set; }
        public DateTime? FechaCotizacion { get; set; }
        public int? CodProveedor { get; set; }
        public string CodEstado { get; set; }
        public int CodArticulo { get; set; }
        public int? Cantidad { get; set; }
        public string NombreArticulo { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreEstado { get; set; }
        public decimal? Precio { get; set; }
        public int CodCotizacion { get; set; }

    }
}