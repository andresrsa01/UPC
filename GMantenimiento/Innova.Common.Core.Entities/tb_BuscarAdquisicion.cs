using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Common.Core.Entities
{
    public class tb_BuscarAdquisicion
    {
        public DateTime? FechaCotizacion { get; set; }

        public string FechaCotizacionn { get; set; }

        public int? CodSolAdquisicion { get; set; }

        public int? CodProveedor { get; set; }

        public string CodEstado { get; set; }

        public int CodArticulo { get; set; }

        public int? Cantidad { get; set; }

        public string NombreProveedor { get; set; }

        public string NombreEstado { get; set; }

        public string NombreArticulo { get; set; }


    }
}
