using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Common.Core.Entities
{
    public class tb_BuscarSolCotizacion
    {
        public int CodSolCotizacion { get; set; }
        public DateTime? FechaCotizacion { get; set; }
        public int CodProveedor { get; set; }
        public string CodEstado { get; set; }
        public int CodArticulo { get; set; }
        public int? Cantidad { get; set; }
        public string NombreArticulo { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreEstado { get; set; }

    }
}
