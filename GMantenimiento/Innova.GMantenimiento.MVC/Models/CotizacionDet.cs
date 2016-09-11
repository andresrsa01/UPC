using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innova.GMantenimiento.MVC.Models
{
    public class CotizacionDet
    {
      
        public int CodSolCotizacion { get; set; }

        public int CodArticulo { get; set; }

        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
    }
}